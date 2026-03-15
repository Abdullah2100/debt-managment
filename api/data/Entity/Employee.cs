namespace data.Entity;



public class Employee:GeneralField
{
     public Guid UserId  { get; set; }
     
     public User User { get; set; }
}