using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Dto.Admin.GenCode.Output
{
    public class GenCodeListOutput
    {
        public string tableName { get; set; }
        public string tableComment { get; set; }
        public string className { get; set; }
        public DateTime? createTime { get; set; }
        public DateTime? updateTime { get; set; }
    }
}
