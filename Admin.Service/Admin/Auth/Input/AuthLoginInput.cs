using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Dto.Admin.Auth.Input
{
    public class AuthLoginInput
    {
        [Required(ErrorMessage ="用户名不能为空")]
        public string username { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        public string password { get; set; }

        [Required(ErrorMessage = "验证码不能为空")]
        public string veriyfcode { get; set; }

        public string verifycodekey { get; set; }

        public string passwordkey { get; set; }

    }
}
