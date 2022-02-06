using Admin.Common.Output;
using Admin.Service.Admin.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Admin.Service.Admin.Auth;

namespace Admin.API.Controllers.Admin
{
    /// <summary>
    /// 授权管理
    /// </summary>
    public class AuthController : AreaController
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public AuthController(IUserService userService,IAuthService authService) {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost]
        public IResponseOutput test()
        {
            var test = _userService.test();
            return test;
        }

        [HttpPost]
        public async Task<IResponseOutput>  add() {
            return await _userService.Add();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IResponseOutput> GetVerifyCode(string lastKey) {
            return await _authService.GetVerifyCode(lastKey);
        }
    }
}
