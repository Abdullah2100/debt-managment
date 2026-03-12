namespace data.Entity;

public class Transaction:GeneralField
{
    public int OldValue { get; private set; }
    public int NewValue { get; private set; }
    
    public Guid OperationId { get; private set; }
    public Guid EditBy { get; private set; }
    public Guid StoreId { get; private set; }
    
    public Employee EditByEmployee { get; private set; }
    public Store Store { get; private set; }
    
}