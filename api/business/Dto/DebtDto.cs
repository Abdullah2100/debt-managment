using business.Dto;
using data.Entity;

namespace business.Entity;

public record class DebtDto
{
    public Guid DebtUserId { get; set; }
    public Guid OperatedByStoreEmployeeUserId { get; set; }
    public Guid StoreId { get; set; }
    
    public  int Value { get; set; }
    public  string Note { get; set; }
     
}

public record class DebtResponseDto:GeneralFieldDto
{
    public Guid DebtUserId { get; set; }
    public Guid OperatedByStoreEmployeeUserId { get; set; }
    public Guid StoreId { get; set; }
    
    public  int Value { get; set; }
    public  string Note { get; set; }
    public UserResponseDto DebtBy { get; set; }
    public StoreResponseDto Store { get; set; }
    public StoreEmployeeUserResponseDto StoreEmployeeUser { get; set; }
     
}
