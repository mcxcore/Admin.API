using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Auth
{
    public interface IPermissionHandler
    {
        Task<bool> ValidateAsync(string Authorize);
    }
}
