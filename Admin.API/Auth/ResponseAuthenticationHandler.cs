using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Admin.API.Auth
{
    public class ResponseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public ResponseAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
            ):base(options,logger,encoder,clock){
        
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new NotImplementedException();
        }

        protected async override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.ContentType = "application/json";
            Response.StatusCode = StatusCodes.Status200OK;
            await Response.WriteAsync(JsonConvert.SerializeObject(
                new ResponseData
                {
                    Success = false,
                    Code = StatusCodes.Status401Unauthorized.ToString(),
                    Msg = ""
                },
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
                ));
        }

        protected async override Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Response.ContentType = "application/json";
            Response.StatusCode = StatusCodes.Status200OK;
            await Response.WriteAsync(JsonConvert.SerializeObject(
                new ResponseData {
                    Success=false,
                    Code=StatusCodes.Status403Forbidden.ToString(),
                    Msg=""
                },
                new JsonSerializerSettings() {
                    ContractResolver=new CamelCasePropertyNamesContractResolver()
                }
                ));
        }
    }

    public class ResponseData {

        [Newtonsoft.Json.JsonIgnore]
        public bool Success { get; set; }
        public string Code { get; set; }

        public string Msg { get; set; }
    }
}
