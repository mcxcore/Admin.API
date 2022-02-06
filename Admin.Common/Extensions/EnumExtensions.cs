using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescription(this Enum item) {
            string name = item.ToString();
            var desc = item.GetType().GetField(name).GetCustomAttribute<DescriptionAttribute>();
            return desc?.Description ?? name;
        }
    }
}
