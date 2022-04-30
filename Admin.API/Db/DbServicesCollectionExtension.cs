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
            string connectionstring = "Server=124.222.246.98; Port=3306; Database=admindb; Uid=root; Pwd=123456; Charset=utf8mb4;";
            string slaveconnect = "Server=103.133.177.134; Port=3306; Database=admindb; Uid=root; Pwd=123456; Charset=utf8mb4;";
            var fsql = new FreeSqlBuilder()
                 .UseConnectionString(DataType.MySql,connectionstring)
                 //.UseSlave(slaveconnect)
                 .UseAutoSyncStructure(true)
                 .UseMonitorCommand(cmd => Trace.WriteLine(cmd.CommandText))
                 .Build();
            services.AddSingleton<IFreeSql>(fsql);
            services.AddScoped<UnitOfWorkManager>();
        }
    }
}
