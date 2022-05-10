using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Admin.Model;
using FreeSql;
namespace Admin.Repository.Admin.GenCode
{
    public class GenTableRepository: DefaultRepository<gen_table, int>, IGenTableRepository
    {
        public GenTableRepository(UnitOfWorkManager uowm):base(uowm?.Orm,uowm) {
            
        }
    }
}
