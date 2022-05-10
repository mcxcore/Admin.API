using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Page
{
    public class PageOutput<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> rows { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public long total { get; set; }
    }
}
