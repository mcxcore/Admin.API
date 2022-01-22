using FreeSql;
using Admin.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repository.Admin.User
{
    public interface IUserRepository:IBaseRepository<UserEntity,int>
    {
        List<UserEntity> GetUsers();
    }
}
