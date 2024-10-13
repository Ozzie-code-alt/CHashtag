using System.ComponentModel.DataAnnotations;

namespace CHashtag.DTOs;

public record class UpdateGameDto(
    [Required] string Name,
    [Required] string Genre,
    [Required] decimal Price,
    DateOnly ReleaseDate
);
