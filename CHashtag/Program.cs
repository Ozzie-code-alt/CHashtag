using CHashtag.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build(); // this is start an instant of building the build
const string getGameEndpointName = "GetGame";

//dotnet run
//dotnet build


// removed the ID
List<GameDto> games =
[
    new(1, "sample1", "sample2nd", 199.9M, new DateOnly(1992, 8, 12)),
    new(2, "sample2", "sample3nd", 199.9M, new DateOnly(1992, 8, 12)),
];

//Get  Games endpoint
app.MapGet("games", () => games);

//get games by id
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
    .WithName(getGameEndpointName);

app.MapGet("/", () => "Hello World!");

// POST Request  / games

app.MapPost(
    "games",
    (CreateGameDto newGame) =>
    {
        GameDto game =
            new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);

        games.Add(game);

        return Results.CreatedAtRoute(getGameEndpointName, new { id = game.Id }, game);
    }
);

//Put Endpoint


app.MapPut(
    "games/{id}",
    (int id, UpdateGameDto updateGame) =>
    {
        //find index first
        //what happends if there is no game ?
        var index = games.FindIndex(game => game.Id == id);
        games[index] = new GameDto(
            id,
            updateGame.Name,
            updateGame.Genre,
            updateGame.Price,
            updateGame.ReleaseDate
        );
        return Results.NoContent();
    }
);

//Delete Endpoint
app.MapDelete(
    "games/{id}",
    (int id) =>
    {
        games.RemoveAll(game => game.Id == id);

        return Results.NoContent();
    }
);

// DTO - Data transfer Object carries data between operations
app.Run();
