using business.Entity;

namespace business.Dto;


public record class BlockedStoreEmployeeUserDto  
{
    public Guid UserId { get; set; }

    public Guid StoreId { get; init; }
    
}
public record class BlockedStoreEmployeeUser : GeneralFieldDto
{
    public Guid UserId { get; set; }

    public Guid StoreId { get; init; }

    public StoreResponseDto? Store { get; set; }
    public UserResponseDto? User { get; set; }
}