using data.Entity;

namespace business.Dto;



public class EmployeeDto
{
     public Guid UserId  { get; set; }
     
}

public record class EmployeeResponseDto:GeneralFieldDto
{
     public Guid UserId  { get; set; }
     
     public User User { get; set; }
}