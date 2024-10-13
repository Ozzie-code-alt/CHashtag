using CHashtag.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build(); // this is start an instant of building the build
app.MapGamesEndpoints();

// DTO - Data transfer Object carries data between operations
app.Run();
