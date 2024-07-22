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
            return app;
        }
    }
}
