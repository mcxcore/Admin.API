using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Auth
{
    public class PermissionHandler : IPermissionHandler
    {
        public Task<bool> ValidateAsync(string Authorize)
        {
            throw new NotImplementedException();
        }
    }
}
