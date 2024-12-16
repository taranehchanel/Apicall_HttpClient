namespace CarService.Api;

public static class ExtensionMethods
{
    static ExtensionMethods()
    {
    }

    public static IApplicationBuilder
        UseMyMiddleware(this IApplicationBuilder app) 
    {
        // UseMiddleware -> //using Microsoft.AspNetCore.Builder;
        return app.UseMiddleware<MyMiddleware>();
    }
}