namespace CarService.Api;

using Microsoft.AspNetCore.Http;

public class MyMiddleware
{
    public MyMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    private RequestDelegate Next { get; }

    public async Task InvokeAsync(HttpContext httpContext)
    {
// اول اجرا می‌شود

        // WriteAsync() -> using Microsoft.AspNetCore.Http;
        httpContext.Response.Redirect("/home/index.cshtml");
        //.WriteAsync(text: "<p>Hello World (1)!</p>");


        await Next(httpContext);

        // بعدی اجرا می‌شود Middleware بعد از اجرای شدن

        // WriteAsync() -> using Microsoft.AspNetCore.Http;
        await httpContext.Response
            .WriteAsync(text: "<p>Hello World (3)!</p>");
    }
}