using business.Entity;

namespace business.Dto;

public record class RePaymentDto
{
    public Guid RePaymentUserId { get; set; }
    public Guid OperatedByStoreEmployeeUserId { get; set; }
    public Guid StoreId { get; set; }

    public int Value { get; set; }
    public string Note { get; set; }
}

public  record class RePaymentResponseDto : GeneralFieldDto
{
    public Guid RePaymentUserId { get; set; }
    public Guid OperatedByStoreEmployeeUserId { get; set; }
    public Guid StoreId { get; set; }

    public int Value { get; set; }
    public string Note { get; set; }

    public UserResponseDto RePaymentBy { get; set; }
    public StoreResponseDto Store { get; set; }
    public StoreEmployeeUserResponseDto StoreEmployeeUser { get; set; }
}