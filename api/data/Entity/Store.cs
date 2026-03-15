namespace data.Entity;

public class Store : GeneralField
{
    public string StoreName { get; set; } = string.Empty;

    public bool IsBlocked { get; set; } = false;
    
    public ICollection<BlockedStoreEmployeeUser> BlockedEmployeeUsersStore { get; set; } = new List<BlockedStoreEmployeeUser>();
    public ICollection<StoreEmployeeUser> EmployeeUsersStore { get; set; } = new List<StoreEmployeeUser>();
    
    public ICollection<Debt> StoreDebt { get; set; } = new List<Debt>();
    public ICollection<RePayment> StoreRepayment { get; set; } = new List<RePayment>();
    public ICollection<Transaction> StoreTransactions { get; set; } = new List<Transaction>();
}