using CHashtag.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build(); // this is start an instant of building the build

//dotnet run
//dotnet build


List<GameDto> games =
[
    new(1, "sample1", "sample2nd", 199.9M, new DateOnly(1992, 8, 12)),
    new(2, "sample2", "sample3nd", 199.9M, new DateOnly(1992, 8, 12)),
];

//Get  Games endpoint
app.MapGet("games", () => games);

//get games by id


app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id));

app.MapGet("/", () => "Hello World!");

// DTO - Data transfer Object carries data between operations





app.Run();
