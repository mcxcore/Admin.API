using Admin.Common.Cache;
using Admin.Common.Helpers;
using Admin.Common.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XC.RSAUtil;

namespace Admin.Service.Admin.Auth
{
    public class AuthService : IAuthService
    {
        private readonly VerifyCodeHelper _verifyCodeHelper;

        public AuthService(VerifyCodeHelper verifyCodeHelper)
        {
            _verifyCodeHelper = verifyCodeHelper;
        }

        public async Task<IResponseOutput> GetPasswordPublicKey() {
            string publicKey = "";
            string privateKey = "";
            var keyList = RsaKeyGenerator.Pkcs1Key(2048,true);
            privateKey = keyList[0];
            publicKey = keyList[1];
            var rsa=new RsaPkcs1Util(Encoding.UTF8,publicKey,privateKey,2048);
            #region 尝试密钥正确性
            string str = "缪晨翔";
            Console.WriteLine("原字符：" + str);
            string desstr=rsa.Encrypt(str, RSAEncryptionPadding.Pkcs1);
            Console.WriteLine("加密后字符：" + desstr);
            string result = rsa.Decrypt(desstr,RSAEncryptionPadding.Pkcs1);
            Console.WriteLine("解密后字符："+result);
            #endregion
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("publicKey",publicKey);
            return ResponseOutput.Ok(dic);
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
