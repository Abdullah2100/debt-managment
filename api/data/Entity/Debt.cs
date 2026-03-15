namespace data.Entity;

public class Debt:GeneralField
{
    public Guid DebtUserId { get; set; }
    public Guid OperatedByStoreEmployeeUserId { get; set; }
    public Guid StoreId { get; set; }
    
    public  int Value { get; set; }
    public  string Note { get; set; }
    
    public User DebtBy { get; set; }
    public Store Store { get; set; }
    public StoreEmployeeUser StoreEmployeeUser { get; set; }
}