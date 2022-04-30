using Admin.API.Db;
using Admin.API.Filters;
using Admin.Common.Attributes;
using Admin.Common.Cache;
using Autofac;
using Dnc.Api.Throttle;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Panda.DynamicWebApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Admin.API
{
    public class Startup
    {
        private readonly IHostEnvironment env;
        private readonly string BasePath = AppContext.BaseDirectory;
        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
            #region 限流
            services.AddApiThrottle(options =>
            {
                options.onIntercepted = (context, value, where) =>
                {
                    var res = new JsonResult(Admin.Common.Output.ResponseOutput.NotOk());
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
                options.RemoveActionPostfixes.Clear();
                options.GetRestFulActionName = (actionName) => actionName;
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            //if(true)
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin.API v1");
                    //c.RoutePrefix = "doc";
                });
            }

            app.UseHttpsRedirection();

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
                 //无接口注入单列
                var assemblyCommon = Assembly.Load("Admin.Common");
                builder.RegisterAssemblyTypes(assemblyCommon)
                    .Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() != null)
                    .SingleInstance();

                //有接口注入单例
                builder.RegisterAssemblyTypes(assemblyCommon)
                    .Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() != null)
                    .AsImplementedInterfaces()
                    .SingleInstance();

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
