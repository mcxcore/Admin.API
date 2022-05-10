using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Configs
{
    public class DbConfig
    {
        /// <summary>
        /// 监听所有操作
        /// </summary>
        public bool monitorCommand { get; set; }
        /// <summary>
        /// 监听Curd操作
        /// </summary>
        public bool curd { get; set; }
        public FreeSql.DataType type { get; set; }
        public string database { get; set; }
        public string connectionString { get; set; }
    }
}
