using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace APIPCHY.MiddleWares
{
    public class TokenVerification : TypeFilterAttribute
    {
        public TokenVerification() : base(typeof(TokenVerificationFilter))
        {
        }

        private class TokenVerificationFilter : IAsyncActionFilter
        {


            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                // Lấy token từ header Authorization
                Console.WriteLine("run");

                // Nếu token hợp lệ, tiếp tục thực hiện action
                await next();
            }



         
        }
    }
}
