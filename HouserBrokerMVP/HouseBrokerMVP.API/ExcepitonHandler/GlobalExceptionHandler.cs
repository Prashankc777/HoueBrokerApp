namespace HouseBrokerMVP.API.ExcepitonHandler;
public class GlobalExceptionHandler(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        var response = context.Response;
        try
        {
            await next(context);
        }
        catch (Exception error)
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            await response.WriteAsJsonAsync(error.Message);
        }
    }
}

