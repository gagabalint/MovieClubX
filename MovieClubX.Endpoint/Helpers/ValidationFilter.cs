using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MovieClubX.Endpoint.Helpers
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var error = new ErrorModel(String.Join(',',context.ModelState.Values.SelectMany(r=>r.Errors.Select(z=>z.ErrorMessage)).ToArray()));
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result=new JsonResult(error);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {}
    }
}
