using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Common.Output;

namespace Admin.Service.Admin.Auth
{
    public interface IAuthService
    {
        Task<IResponseOutput> GetVerifyCode(string lastKey);
    }
}
