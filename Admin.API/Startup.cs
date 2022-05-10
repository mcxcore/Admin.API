using Admin.API.Auth;
using Admin.API.Db;
using Admin.API.Filters;
using Admin.Common.Attributes;
using Admin.Common.Auth;
using Admin.Common.Cache;
using Admin.Common.Configs;
using Admin.Common.Helpers;
using Autofac;
using Dnc.Api.Throttle;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Panda.DynamicWebApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;

namespace Admin.API
{
    public class Startup
    {
        private readonly IHostEnvironment env;
        private readonly string BasePath = AppContext.BaseDirectory;
        private readonly ConfigHelper _configHelper;
        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
            _configHelper = new ConfigHelper();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region 身份认证授权
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            services.TryAddSingleton<IUser, User>();
            var jwtConfig = _configHelper.Get<JwtConfig>("jwt",env.EnvironmentName,true);
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = nameof(ResponseAuthenticationHandler);
                options.DefaultForbidScheme = nameof(ResponseAuthenticationHandler);
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuser,
                    ValidAudience = jwtConfig.Audience,
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecurityKey)),
                    ClockSkew = TimeSpan.Zero
                };
            })
            .AddScheme<AuthenticationSchemeOptions, ResponseAuthenticationHandler>(nameof(ResponseAuthenticationHandler),o=> { });
            #endregion
            //数据库
            services.AddDbAsync(env).Wait();
            services.AddControllers(options=> {
                options.Filters.Add<AdminExceptionFilter>();
                options.Filters.Add(typeof(ApiThrottleActionFilter));

            });
            if (true)
            {
                var redis = new CSRedis.CSRedisClient("124.222.246.98:6379,password=123456,defaultDatabase=0");
                RedisHelper.Initialization(redis);
                services.AddSingleton<ICache,RedisCache>();
            }
            services.AddSwaggerGen(c =>
            {
                c.DocInclusionPredicate((docName, description) => true);
                c.CustomSchemaIds(type => type.FullName);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Admin.API", Version = "v1" });

                var xmlPath = Path.Combine(BasePath,"Admin.API.xml");
                c.IncludeXmlComments(xmlPath,true);
            });

            #region AutoMapper映射
            var assembly = Assembly.Load("Admin.Dto");
            services.AddAutoMapper(assembly);
            #endregion
            #region 限流
            services.AddApiThrottle(options =>
            {
                options.onIntercepted = (context, value, where) =>
                {
                    var res = new JsonResult(Admin.Common.ResponseOutput.ResponseOutput.NotOk());
                    return res;
                };
                options.UseRedisCacheAndStorage(opts =>
                {
                    opts.ConnectionString = "124.222.246.98:6379,password=123456,defaultDatabase=0";
                });
            });
            #endregion

            #region 动态API
            services.AddDynamicWebApi((options) => {
                options.DefaultApiPrefix = "api/[area]";
                options.RemoveControllerPostfixes = new List<string>() {"Service" };
                options.RemoveActionPostfixes = new List<string>() { "Async" };
                options.GetRestFulActionName = (actionName) => actionName;

            });
            #endregion

            #region 验证码
            var builder =new ConfigurationBuilder().Build();
            services.AddCaptcha(builder);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            if(true)
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin.API v1");
                    //c.RoutePrefix = "doc";
                });
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseApiThrottle();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder) {
            #region Autofac IOC容器
            try
            {

                var assemblyCommon = Assembly.Load("Admin.Common");

                //无接口注入单例
                builder.RegisterAssemblyTypes(assemblyCommon)
                   .Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() != null)
                   .SingleInstance();

                builder.RegisterAssemblyTypes(assemblyCommon)
                .Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() != null)
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope()
                  .PropertiesAutowired();

                builder.RegisterAssemblyTypes(assemblyCommon)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired();

                //Repository
                var assemblyRepository = Assembly.Load("Admin.Repository");
                builder.RegisterAssemblyTypes(assemblyRepository)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope()
                    .PropertiesAutowired();

                //Service
                var assemblyService = Assembly.Load("Admin.Service");
                 builder.RegisterAssemblyTypes(assemblyService)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope()
                    .PropertiesAutowired();
            }
            catch (Exception ex) {
                
            }
            #endregion
        }
    }
}
