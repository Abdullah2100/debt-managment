using System.ComponentModel.DataAnnotations;

namespace business.Dto;

public record class GeneralFieldDto
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }
}