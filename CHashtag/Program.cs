using CHashtag.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build(); // this is start an instant of building the build

//dotnet run
//dotnet build


List<GameDto> games = [new(1, "sample1", "sample2nd", 199, new DateOnly(1992, 8, 12))];
app.MapGet("/", () => "Hello World!");

// DTO - Data transfer Object carries data between operations





app.Run();
