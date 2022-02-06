using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Model.Admin
{
    [Table(Name ="ad_user")]
    public class UserEntity
    {
        [Column(IsPrimary =true,IsIdentity =true)]
        public int id { get; set; }
        public string name { get; set; }

        public string sex { get; set; }

        public string bz { get; set; }
    }
}
