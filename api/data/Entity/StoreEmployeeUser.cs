namespace data.Entity;

[Flags]
public enum EnPermission
{
    Create,
    Update,
    View,
    Both = Create & Update & View
}

public class StoreEmployeeUser : GeneralField
{
    public Guid UserId { get; set; }
    public Guid StoreId { get; init; }
    
    public bool IsMainStoreAdmin { get; init; } = false;
    public bool IsActive { get; init; } = false;
    
    public EnPermission Permission { get; set; } = EnPermission.Create;

    public Store? Store { get; set; }
    public User? User { get; set; }
    
    public ICollection<Debt> StoreDebt { get; set; } = new List<Debt>();
    public ICollection<RePayment> StoreRepayment { get; set; } = new List<RePayment>();
    public ICollection<Transaction> StoreOperationTransactions { get; set; } = new List<Transaction>();
}