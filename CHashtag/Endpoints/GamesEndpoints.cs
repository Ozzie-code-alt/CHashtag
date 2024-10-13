using CHashtag.DTOs;
using MiniValidation;

namespace CHashtag.Endpoints;

public static class GamesEndpoints
{
    const string getGameEndpointName = "GetGame";
    private static readonly List<GameDto> games =
    [
        new(1, "sample1", "sample2nd", 199.9M, new DateOnly(1992, 8, 12)),
        new(2, "sample2", "sample3nd", 199.9M, new DateOnly(1992, 8, 12)),
    ];

    //Decalre our extension method - declare an Existing Class
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        //replace all apps.Function in routes to this since same endpoint (includes group)
        var group = app.MapGroup("games");
        //Get  Games endpoint
        app.MapGet("games", () => games);

        //get games by id
        group
            .MapGet(
                "/{id}",
                (int id) =>
                {
                    GameDto? game = games.Find(game => game.Id == id);

                    //Look into this - more of like an appropriate handling of no Games or invalid params id
                    return game is null ? Results.NotFound() : Results.Ok(game);
                }
            )
            .WithName(getGameEndpointName);

        app.MapGet("/", () => "Hello World!");

        // POST Request  / games
        group
            .MapPost(
                "/",
                (CreateGameDto newGame) =>
                {
                    /*
                    Singular approachd
                    if(string.IsNullOrEmpty(newGame.Name)){
                        return Results.BadRequest("Name Is Required");
                    }
                    */
                    // we can handle validations in C# by using annotations
                    if (!MiniValidator.TryValidate(newGame, out var errors))
                    {
                        return Results.ValidationProblem(errors);
                    }
                    GameDto game =
                        new(
                            games.Count + 1,
                            newGame.Name,
                            newGame.Genre,
                            newGame.Price,
                            newGame.ReleaseDate
                        );

                    games.Add(game);

                    return Results.CreatedAtRoute(getGameEndpointName, new { id = game.Id }, game);
                }
            )
            .WithParameterValidation();

        //Put Endpoint
        group
            .MapPut(
                "/{id}",
                (int id, UpdateGameDto updateGame) =>
                {
                    //find index first
                    //what happends if there is no game ?
                    var index = games.FindIndex(game => game.Id == id);

                    if (index == -1) // Out of bounds
                    {
                        return Results.NotFound();
                    }

                    games[index] = new GameDto(
                        id,
                        updateGame.Name,
                        updateGame.Genre,
                        updateGame.Price,
                        updateGame.ReleaseDate
                    );
                    return Results.NoContent();
                }
            )
            .WithParameterValidation();

        //Delete Endpoint
        group.MapDelete(
            "/{id}",
            (int id) =>
            {
                games.RemoveAll(game => game.Id == id);

                return Results.NoContent();
            }
        );

        return group;
    }
}
