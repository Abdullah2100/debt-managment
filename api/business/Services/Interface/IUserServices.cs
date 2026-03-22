using business.Dto;

namespace business.Services.Interface;

public interface IUserServices
{
    Task<Result<AuthDto>> Login(UserLoginDto user);
    Task<Result<AuthDto>> Register(UserDto data);
    
    Task<Result<bool>> GenerateOtp(UserGenerateOtpDto data);
    Task<Result<bool>> VerifyingOtp(UserVerifyingOtpDto data);
    Task<Result<AuthDto>> UpdateUserPassword(UserUpdatePasswordDto data);
    
    Task<Result<UserDto>> UpdateUserPassword(UserUpdateDto data);
    
}