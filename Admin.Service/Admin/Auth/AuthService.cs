using Admin.Common.Cache;
using Admin.Common.Helpers;
using Admin.Common.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Service.Admin.Auth
{
    public class AuthService : IAuthService
    {
        private readonly VerifyCodeHelper _verifyCodeHelper;

        public AuthService(VerifyCodeHelper verifyCodeHelper)
        {
            _verifyCodeHelper = verifyCodeHelper;
        }

        public async Task<IResponseOutput> GetVerifyCode(string lastKey)
        {
            //Byte gtServerStatus =geetest.preProcess();
            //var s=geetest.getResponseStr();
            //string s = _verifyCodeHelper.GenerateRandom(4);
            string code = "";
            string s=_verifyCodeHelper.GetBase64String(out code);
            s=string.Format(CacheKey.VerifyCodeKey,"111");
            await Task.Delay(100);
            return ResponseOutput.Ok();
        }
    }
}
