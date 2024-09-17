var builder = WebApplication.CreateBuilder(args);
var app = builder.Build(); // this is start an instant of building the build

app.MapGet("/", () => "Hello World!");

app.Run();
