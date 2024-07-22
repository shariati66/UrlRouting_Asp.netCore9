using UrlRouting_Asp.netCore9;

var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();
var app = builder.ConfigureServices().ConfigurePipeline();

app.MapGet("/", () => "Hello World!");

app.Run();
