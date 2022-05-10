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
    public class BaseService: IDynamicWebApi
    {
    }
}
