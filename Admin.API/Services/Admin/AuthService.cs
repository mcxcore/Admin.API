using Admin.Common.Cache;
using Admin.Common.Helpers;
using Admin.Common.Output;
using Admin.Dto.Admin.Auth.Input;
using Admin.Dto.Admin.Auth.Output;
using Microsoft.AspNetCore.Mvc;
using Panda.DynamicWebApi;
using Panda.DynamicWebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Services.Admin
{
    [Area("admin")]
    [DynamicWebApi]
    public class AuthService :IDynamicWebApi
    {
        private readonly ICache _cache;
        private readonly VerifyCodeHelper _verifyCodeHelper;
        public AuthService(ICache cache,VerifyCodeHelper verifyCodeHelper)
        {
            _cache = cache;
            _verifyCodeHelper = verifyCodeHelper;
        }

        [HttpPost]
        public async Task<IResponseOutput> LoginAsync(AuthLoginInput input)
        {
            return ResponseOutput.Ok();
        }

        public async Task<IResponseOutput> GetPasswordPublicKey() {
            string s = "";
            return ResponseOutput.Ok(s);
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="lastKey"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> GetVerifyCode(string lastKey) {
            if (lastKey.NotNull())
            {
                await _cache.DelAsync(lastKey);
            }
            string s = "data:image/jpg;base64," + _verifyCodeHelper.GetBase64String(out string code);
            var guid = Guid.NewGuid().ToString();
            string key = string.Format(CacheKey.VerifyCodeKey, guid);
            await _cache.SetAsync(key, code, TimeSpan.FromMinutes(1));
            var data = new AuthGetVerifyCodeOutput { key = key, img = s };
            return ResponseOutput.Ok(data);
        }
    }
}
