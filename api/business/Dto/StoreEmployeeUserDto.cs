using business.Entity;

namespace business.Dto;

[Flags]
public enum EnPermission
{
    Create,
    Update,
    View,
    Both = Create & Update & View
}

public record class StoreEmployeeUserDto
{
    public Guid UserId { get; set; }
    public Guid StoreId { get; init; }

    public bool IsMainStoreAdmin { get; init; } = false;
    public bool IsActive { get; init; } = false;
    public EnPermission Permission { get; set; } = EnPermission.Create;
}

public record class StoreEmployeeUserResponseDto : GeneralFieldDto
{
    public Guid UserId { get; set; }
    public Guid StoreId { get; init; }

    public bool IsMainStoreAdmin { get; init; } = false;
    public bool IsActive { get; init; } = false;

    public EnPermission Permission { get; set; } = EnPermission.Create;

    public StoreResponseDto Store { get; set; }
    public UserResponseDto User { get; set; }
}