using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSql;
using System.Diagnostics;

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
            string connectionstring = "Server=124.223.69.99; Port=3306; Database=admindb_test; Uid=root; Pwd=root; Charset=utf8mb4;";
            var fsql = new FreeSqlBuilder()
                 .UseConnectionString(DataType.MySql,connectionstring)
                 .UseAutoSyncStructure(true)
                 .UseNameConvert(FreeSql.Internal.NameConvertType.PascalCaseToUnderscoreWithLower)
                 .UseMonitorCommand(cmd => Trace.WriteLine(cmd.CommandText))
                 .Build();
            services.AddSingleton<IFreeSql>(fsql);
            services.AddScoped<UnitOfWorkManager>();
        }
    }
}
