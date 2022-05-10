using Admin.Common.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true)]
    public class LoginAttribute : Attribute, IAuthorizationFilter, IAsyncAuthorizationFilter
    {
        public async Task AuthAsync(AuthorizationFilterContext context) {
            if (context.ActionDescriptor.EndpointMetadata.Any(l => l.GetType() == typeof(AllowAnonymousAttribute)))
                return;
            //登录验证
            var user = context.HttpContext.RequestServices.GetService<IUser>();
            if (user == null || !(user?.userId > 0))
            {
                context.Result = new ChallengeResult();
                return;
            }
        }
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            await AuthAsync(context);
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            await AuthAsync(context);
        }
    }
}
