using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Cache
{
    public static class CacheKey
    {
        /// <summary>
        /// 验证码键
        /// </summary>
        public const string VerifyCodeKey = "admin:verify:code:{0}";

        /// <summary>
        /// 用户权限
        /// </summary>
        public const string UserPermissionKey = "admin:user:permission:{0}";

        /// <summary>
        /// 用户登录错误次数
        /// </summary>
        public const string LoginErrorCountKey = "admin:login:error:{0}";
    }
}
