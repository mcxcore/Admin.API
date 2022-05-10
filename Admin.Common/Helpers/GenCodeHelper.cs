using Admin.Common.Configs;
using Masuit.Tools.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Admin.Common.Helpers
{
    /// <summary>
    /// 代码生成
    /// </summary>
    public static class GenCodeHelper
    {
        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <returns></returns>
        public static List<FreeSql.DatabaseModel.DbTableInfo> GetTables(this IFreeSql freeSql, IHostEnvironment env) {
            var dbConfig = new ConfigHelper().Get<DbConfig>("db",env.EnvironmentName,true);
            var dbInfo = freeSql.DbFirst.GetTablesByDatabase(dbConfig.database);
            return dbInfo;
        }
    }
}
