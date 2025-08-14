// Authorization Filter
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

public class MyAuthFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Giả sử user không có quyền
        bool hasAccess = true; // đổi false để thử short-circuit
        if (!hasAccess)
        {
            context.Result = new ForbidResult(); // dừng pipeline tại đây
        }
    }
}

// Resource Filter
public class MyResourceFilter : IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        Console.WriteLine("ResourceFilter: OnResourceExecuting");
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        Console.WriteLine("ResourceFilter: OnResourceExecuted");
    }
}

// Action Filter
public class MyActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("ActionFilter: OnActionExecuting");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("ActionFilter: OnActionExecuted");
    }
}

// Exception Filter
public class MyExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        Console.WriteLine("ExceptionFilter: Exception occurred - " + context.Exception.Message);
        context.Result = new ObjectResult(new { error = context.Exception.Message })
        {
            StatusCode = 500
        };
    }
}

// Result Filter
public class MyResultFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        Console.WriteLine("ResultFilter: OnResultExecuting");
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        Console.WriteLine("ResultFilter: OnResultExecuted");
    }
}
