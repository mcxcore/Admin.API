using Admin.Model;
using FreeSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repository.Admin.User
{
    public class UserRepository: DefaultRepository<ad_user,int>, IUserRepository
    {
        public UserRepository(UnitOfWorkManager uowm):base(uowm?.Orm,uowm) {
            
        }
    }
}
