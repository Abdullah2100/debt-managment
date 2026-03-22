namespace business.Dto;

public class StoreDto
{
    public string StoreName { get; set; } = string.Empty;
}

public record class StoreResponseDto : GeneralFieldDto
{
    public string StoreName { get; set; } = string.Empty;

    public bool IsBlocked { get; set; } = false;
}