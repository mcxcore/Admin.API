using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSql;
using System.Diagnostics;
using Admin.Common.Helpers;
using Admin.Common.Configs;
using Admin.API.Services.Admin;
using Admin.Common.Auth;

namespace Admin.API.Db
{
    /// <summary>
    /// 数据库服务扩展
    /// </summary>
    public static class DbServicesCollectionExtension
    {
        /// <summary>
        /// 添加数据库
        /// </summary>
        /// <param name="services"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public async static Task AddDbAsync(this IServiceCollection services, IHostEnvironment env)
        {
            var dbConfig = new ConfigHelper().Get<DbConfig>("db", env.EnvironmentName, true);
            var freeSqlBuilder = new FreeSqlBuilder()
                 .UseConnectionString(dbConfig.type, dbConfig.connectionString);
            if (dbConfig.monitorCommand) {
                freeSqlBuilder.UseMonitorCommand(cmd =>
                {
                    Console.WriteLine(cmd.CommandText);
                    //Trace.WriteLine(cmd.CommandText);
                });
            }
            var freesql = freeSqlBuilder.Build();
            if (dbConfig.curd) {
                freesql.Aop.CurdBefore += (s, e) =>
                {
                    Console.WriteLine($"{e.Sql}\r\n");
                };
            }
            #region 审计数据
            var user = services.BuildServiceProvider().GetRequiredService<IUser>();
            freesql.Aop.AuditValue += (s, e) =>
            {
                if (e.AuditValueType == FreeSql.Aop.AuditValueType.Insert)
                {
                    switch (e.Property.Name)
                    {
                        case "createTime": e.Value = DateTime.Now; break;
                        case "createBy": e.Value = "system"; break;
                    }
                }
                else if (e.AuditValueType == FreeSql.Aop.AuditValueType.Update) {
                    switch (e.Property.Name) 
                    {
                        case "updateTime":e.Value = DateTime.Now; break;
                        case "updateBy":e.Value = "system"; break;
                    }
                }
            };
            #endregion
            services.AddSingleton<IFreeSql>(freesql);
            services.AddScoped<UnitOfWorkManager>();
        }
    }
}
