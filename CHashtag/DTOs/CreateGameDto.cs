using System.ComponentModel.DataAnnotations;

namespace CHashtag.DTOs;

//data annotations - defined what is expected of these properties
//PS this is not enough we need another package to enforce this ()
//this is a mistake
public record class GameDto(
    int Id,
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    [Required] DateOnly ReleaseDate
);
