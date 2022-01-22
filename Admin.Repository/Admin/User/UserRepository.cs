using Admin.Model.Admin;
using FreeSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repository.Admin.User
{
    public class UserRepository: DefaultRepository<UserEntity,int>, IUserRepository
    {
        public UserRepository(UnitOfWorkManager uowm):base(uowm?.Orm,uowm) {
            
        }
        public List<UserEntity> GetUsers() {
            return Select.Page(1, 10).ToList();
        }
    }
}
