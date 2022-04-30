using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Auth
{
    public interface IUser
    {
        long userId { get; }

        string userName { get; }

        string userNickName { get; }

        string userRoles { get; }
    }
}
