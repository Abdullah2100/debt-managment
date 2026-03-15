namespace data.Entity;


public class BlockedStoreEmployeeUser : GeneralField
{
    public Guid UserId { get; set; }

    public Guid StoreId { get; init; }

    public Store? Store { get; set; }
    public User? User { get; set; }
}