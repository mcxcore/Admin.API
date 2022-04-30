using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public static class StringExtensions
    {
        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool isNull(this string s) {
            return string.IsNullOrWhiteSpace(s);
        }

        public static bool NotNull(this string s) {
            return !string.IsNullOrWhiteSpace(s);
        }
    }
}
