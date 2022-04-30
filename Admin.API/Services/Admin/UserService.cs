using Admin.Common.Output;
using Microsoft.AspNetCore.Mvc;
using Panda.DynamicWebApi;
using Panda.DynamicWebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Services.Admin
{
    /// <summary>
    /// 用户服务
    /// </summary>
    [Area("admin")]
    [DynamicWebApi]
    public class UserService:IDynamicWebApi
    {
        public async Task<IResponseOutput> Add() {
            return ResponseOutput.Ok();
        }
    }
}
