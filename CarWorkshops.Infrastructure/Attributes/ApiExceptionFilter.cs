using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace CarWorkshops.Infrastructure.Attributes
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public ApiExceptionFilter(string controllerName)
        {
            //initialize a logger
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            await LogException(context);
            SetResult(context);

            await base.OnExceptionAsync(context);
        }

        private async Task LogException(ExceptionContext context)
        {
            var actionDescriptor = context.ActionDescriptor;
            var query = context.HttpContext.Request.QueryString.Value;

            //Log exception here
            await Task.Run(() => { });
        }

        private void SetResult(ExceptionContext context)
        {
            context.Result = new JsonResult(new { message = context.Exception.Message })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
