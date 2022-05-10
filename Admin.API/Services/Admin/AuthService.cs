using Admin.Common.Auth;
using Admin.Common.Cache;
using Admin.Common.Helpers;
using Admin.Common.ResponseOutput;
using Admin.Dto.Admin.Auth.Input;
using Admin.Dto.Admin.Auth.Output;
using Admin.Model;
using Dnc.Api.Throttle;
using Lazy.Captcha.Core;
using Masuit.Tools.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Panda.DynamicWebApi;
using Panda.DynamicWebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Admin.API.Services.Admin
{
    [Area("admin")]
    [DynamicWebApi]
    public class AuthService :IDynamicWebApi
    {
        private readonly ICache _cache;
        private readonly IUserToken _userToken;
        private readonly ICaptcha _captcha;
        public AuthService(ICache cache,IUserToken userToken,ICaptcha captcha)
        {
            _cache = cache;
            _userToken = userToken;
            _captcha = captcha;
        }

        [HttpPost]
        [RateValve(Policy = Policy.Ip, Limit = 10, Duration = 30)]
        public async Task<IResponseOutput> LoginAsync(AuthLoginInput input)
        {
            var data = new AuthLoginOutput() {userId=1,userName="admin",nickName="缪",roles=new List<string> {"admin","system" } };
            var output = ResponseOutput.Ok(data);
            return await GetToken((ResponseOutput<AuthLoginOutput>)output);
        }

        public async Task<IResponseOutput> GetPasswordPublicKey() {
            string s = "";
            return ResponseOutput.Ok(s);
        }

        public async Task<IResponseOutput> GetVerifyCode(string lastKey) {
            if (lastKey.NotNull())
            {
                await _cache.DelAsync(lastKey);
            }
            var guid = Guid.NewGuid().ToString();
            var captchaInfo= _captcha.Generate(guid);
            string key = string.Format(CacheKey.VerifyCodeKey, guid);
            await _cache.SetAsync(key, captchaInfo.Code, TimeSpan.FromMinutes(1));
            var data = new AuthGetVerifyCodeOutput { key = key, img =captchaInfo.Base64 };
            return ResponseOutput.Ok(data);
        }

        public async Task<IResponseOutput> GetTimeNow() {
            var datetime = DateTime.Now;
            return ResponseOutput.Ok(datetime);
        }

        private async  Task<IResponseOutput> GetToken(ResponseOutput<AuthLoginOutput> output) {
            if (!output.Success) return ResponseOutput.NotOk(output.Msg);

            var user = output.Data;

            var token = _userToken.Create(
                new[] {
                    new Claim(ClaimAttributes.userId,user.userId.ToString()),
                    new Claim(ClaimAttributes.userName,user.userName.ToString()),
                    new Claim(ClaimAttributes.userNickName,user.nickName.ToString()),
                    new Claim(ClaimAttributes.userRoles,JsonConvert.SerializeObject(user.roles)),
                }
                );
            return ResponseOutput.Ok(new {token });
        }
    }
}
