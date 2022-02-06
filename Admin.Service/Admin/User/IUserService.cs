using Admin.Common.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Service.Admin.User
{
    public interface IUserService
    {
        IResponseOutput test();

        Task<IResponseOutput> Add();
    }
}
