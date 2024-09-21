namespace CHashtag.DTOs;

//records are immutable - cannot be changed
public record class CreateGameDto(string Name, string Genre, decimal Price, DateOnly ReleaseDate);
