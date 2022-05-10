using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Page
{
    public class PageInput<T>
    {
        public int pageIndex { get; set; } = 1;

        public int pageSize { get; set; } = 15;

        public T? Filter { get; set; } 
    }
}
