namespace UrlRouting_Asp.netCore9
{
    public static class HostingExtension
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.MapGet("/ingredients/{name}", new IngredientMiddleware().InvokeAsync);
            return app;
        }
    }
}
