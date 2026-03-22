using data.Entity;

namespace business.Dto;

public class TransactionDto
{
    public Guid OperationId { get; private set; }
    public Guid CreatedById { get; private set; }
    public Guid StoreId { get; private set; }
    
    public int? OldValue { get; private set; }
    public int? NewValue { get; private set; }
    
    public string? OldNote { get; private set; }
    public string? NewNote { get; private set; }
    
    public bool IsUpdated  { get; private set; }
    public bool IsDebt  { get; private set; }
    
    
    public StoreEmployeeUser StoreEmployeeUser { get; private set; }
    public Store Store { get; private set; }
    
}

