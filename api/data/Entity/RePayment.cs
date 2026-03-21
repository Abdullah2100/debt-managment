namespace data.Entity;

public class RePayment : GeneralField
{
    public Guid RePaymentUserId { get; set; }
    public Guid OperatedByStoreEmployeeUserId { get; set; }
    public Guid StoreId { get; set; }

    public int Value { get; set; }
    public string Note { get; set; }

    public User RePaymentBy { get; set; }
    public Store Store { get; set; }
    //this the storeemployye user how do the operation
    public StoreEmployeeUser StoreEmployeeUser { get; set; }
}