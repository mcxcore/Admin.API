using Admin.API.Attributes;
using Admin.Common.ResponseOutput;
using Admin.Model;
using Admin.Repository.Admin.User;
using Microsoft.AspNetCore.Mvc;
using Panda.DynamicWebApi;
using Panda.DynamicWebApi.Attributes;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Admin.API.Services.Admin
{
    /// <summary>
    /// 用户服务
    /// </summary>
    [Area("admin")]
    [DynamicWebApi]
    public class UserService:IDynamicWebApi
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [Login]
        public async Task<IResponseOutput> Get() {
            //var entity = new ad_user() { deptId = 100,userName= };
            var data=await _userRepository.Where(u=>true).ToListAsync();
            return ResponseOutput.Ok(data);
        }


    }
}
