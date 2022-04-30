using Admin.Common.Output;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.API.Enums;

namespace Admin.API.Filters
{
    public class AdminExceptionFilter : IExceptionFilter, IAsyncExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<AdminExceptionFilter> _logger;

        public AdminExceptionFilter(IWebHostEnvironment env, ILogger<AdminExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            string message;
            if (_env.IsProduction())
            {
                //message = StatusCode.Status500InternalServerError.ToDescription();
                message = context.Exception.Message;
            }
            else {
                message = context.Exception.Message;
            }   
            var data = ResponseOutput.NotOk(message);
            context.Result = new InternalServerErrorResult(data);
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        } 
    }

    public class InternalServerErrorResult : ObjectResult {
        public InternalServerErrorResult(object value) : base(value) {
            StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status200OK;
        }
    }
}
