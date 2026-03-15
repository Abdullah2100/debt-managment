namespace data.Entity;

public class EmployeeBlockedByStore : GeneralField
{
   public Guid EmployeeId {get; set;}

    public Guid StoreId { get; set; }
    
   public Store Store {get; set;}
   public Employee Employee {get; set;}
}