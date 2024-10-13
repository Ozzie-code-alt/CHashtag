namespace CHashtag.DTOs;

using System.ComponentModel.DataAnnotations;
//data annotations - defined what is expected of these properties
//PS this is not enough we need another package to enforce this ()
//records are immutable - cannot be changed
public record class CreateGameDto(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    [Required] DateOnly ReleaseDate
);
