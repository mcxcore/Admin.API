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
        [Column(IsPrimary = true, IsIdentity = true)]
        public int id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Column(StringLength =50)]
        public string user_name { get; set; }
        [Column(StringLength =50)]
        public string nick_name { get; set; }
        [Column(StringLength =10)]
        public string user_type { get; set; }
        [Column(StringLength =50)]
        public string email { get; set; }
        [Column(StringLength =20)]
        public string phonenumber { get; set; }
        [Column(StringLength =2)]
        public char sex { get; set; }
        [Column(StringLength =100)]
        public string avatar { get; set; }
        [Column(StringLength =100)]
        public string password { get; set; }
        [Column(StringLength =500)]
        public string bz { get; set; }
    }
}
