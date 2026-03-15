using System.ComponentModel.DataAnnotations.Schema;

namespace data.Entity;

public class User:GeneralField
{
    [Column(TypeName = "nvarchar(50)")]
    public string FullName { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar(15)")]
    public string Phone { get; set; } = string.Empty; 
}