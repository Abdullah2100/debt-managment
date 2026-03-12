namespace data.Entity;

public class Store :GeneralField
{
    public string StoreName { get; set; } = string.Empty; 
    
    public Guid OwnerEmployeeId { get; set; }
    public Guid OwnerUesrId { get; set; }

    public User User { get; set; } 
    
    
    public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
}