using System.ComponentModel.DataAnnotations;

namespace data.Entity;

public  abstract class GeneralField:UpdateAtField
{
    [Key] public Guid  Id { get; init; }
    public DateTime CreatedAt { get; set; }
}

public class UpdateAtField
{
    public DateTime UpdateAt { get; set; }
 
} 