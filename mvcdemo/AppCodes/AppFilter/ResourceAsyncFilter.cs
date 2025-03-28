using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace mvcdemo.Filters
{
    public class ResourceAsyncFilter : IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            await context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");

            await next();

            await context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }
}
