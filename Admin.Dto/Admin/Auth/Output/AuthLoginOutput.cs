using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Dto.Admin.Auth.Output
{
    public class AuthLoginOutput
    {
        public long userId { get; set; }

        public string userName { get; set; }

        public string nickName { get; set; }

        public List<string> roles { get; set; }
    }
}
