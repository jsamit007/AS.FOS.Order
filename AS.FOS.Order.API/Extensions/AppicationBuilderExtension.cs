namespace AS.FOS.Order.Core.Extensions;

internal static class AppicationBuilderExtension
{
    public static IApplicationBuilder ApplicationBuilder(this IApplicationBuilder app)
    {
        var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
        //var endpoints = app.ApplicationServices.GetRequiredService<IEndpointRouteBuilder>();
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(opt =>
        {
            opt.MapControllers();
        });
        return app;
    }
}
