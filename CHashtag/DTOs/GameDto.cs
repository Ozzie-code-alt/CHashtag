namespace CHashtag.DTOs;
//records are immutable - cannot be changed
public record class GameDto(int Id, string Name, string Genre, decimal Price, DateOnly ReleaseDate);
