using data.Entity;

namespace business.Dto;

public class UserDto
{
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public record class UserResponseDto : GeneralFieldDto
{
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;


    public EmployeeResponseDto? Employee { get; set; }
    public StoreEmployeeUser? StoreEmployeeUser { get; set; }
}