using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Auth
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public User(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual long userId {
            get {
                var id = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimAttributes.userId);
                if (id != null && id.Value != "") {
                    return 1L;
                }
                return 0L;
            }
        }

        public string userName {
            get {
                var name = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimAttributes.userName);
                if (name != null && name.Value != "") {
                    return name.Value;
                }
                return "";
            }
        }

        public string userNickName {
            get {
                var name = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimAttributes.userNickName);
                if (name != null && name.Value != "")
                {
                    return name.Value;
                }
                return "";
            }
        }

        public string userRoles {
            get {
                var name = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimAttributes.userRoles);
                if (name != null && name.Value != "")
                {
                    return name.Value;
                }
                return "";
            }
        }
    }
}
