namespace Restaurants.API.Middlewares;

public class ErrorHandlingMidlleware : IMiddleware
{
    private readonly ILogger<ErrorHandlingMidlleware> logger;

    public ErrorHandlingMidlleware(ILogger<ErrorHandlingMidlleware> logger)
    {
        this.logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }catch(Exception ex) {
            logger.LogError(ex, ex.Message);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("Something went wrong");
        }
    }
}
