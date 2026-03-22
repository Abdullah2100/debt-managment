using data.Entity;

namespace business.Dto;

public class UserDto
{
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
public class UserUpdateDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public record UserLoginDto
{
    public string EmailOrPhone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public record class UserResponseDto : GeneralFieldDto
{
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public EmployeeResponseDto? Employee { get; set; }
    public StoreEmployeeUser? StoreEmployeeUser { get; set; }
}



public record UserGenerateOtpDto
{
    public string EmailOrPhone { get; set; } = string.Empty;
}

public record OtpGenerateDto
{
    public string Otp { get; set; } = string.Empty;
}


public record UserVerifyingOtpDto
{
    public string EmailOrPhone { get; set; } = string.Empty;
    public string Otp { get; set; } = string.Empty;
}

public record UserUpdatePasswordDto
{
    public string EmailOrPhone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}