using Microsoft.AspNetCore.Mvc.Filters;

namespace EduManage.Filters
{
    public class MyCustomExceptionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ContentResult() { Content = "Please contact the admin" };
               // context.Result = RedirectToAction("home/error");
            }
            base.OnActionExecuted(context);
        }
    }
}
