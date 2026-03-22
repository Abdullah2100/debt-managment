namespace business.Dto;

public record class AuthDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
