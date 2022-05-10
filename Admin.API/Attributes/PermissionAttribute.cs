using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Attributes
{
    /// <summary>
    /// 权限属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAttribute : ActionFilterAttribute, IAuthorizationFilter, IAsyncAuthorizationFilter
    {
        public PermissionAttribute(string authorize)
        {
            Authorize = authorize;
        }

        private string Authorize { get; set; }

        public async Task PermissionAuthorization(AuthorizationFilterContext context) 
        {

        }


        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            await PermissionAuthorization(context);
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            await PermissionAuthorization(context);
        }
    }
}
