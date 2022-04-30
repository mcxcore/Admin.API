using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Dto.Admin.Auth.Output
{
    /// <summary>
    /// 返回验证码
    /// </summary>
    public class AuthGetVerifyCodeOutput
    {
        public string key { get; set; }

        public string img { get; set; }
    }
}
