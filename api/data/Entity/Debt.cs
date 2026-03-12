namespace data.Entity;

public class Debt:GeneralField
{
    public Guid UserId { get; set; }
    public  int Value { get; set; }
    public  Guid AddedBy  { get; set; }
    public Guid StoreId { get; set; }
    
    public User User { get; set; }
    public Store Store { get; set; }
    public Employee EmployeeAdded { get; set; }
}