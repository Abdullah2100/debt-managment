namespace data.Entity;

[Flags]
public enum EnPermission{Create,Update ,Both}

public class Employee:GeneralField
{
     public EnPermission Permission { get; set; }
     public Guid StoreId  { get; set; }
     public Guid UserId  { get; set; }
     
     public User User { get; set; }
     public IEnumerable<Store> Stores { get; set; } =  new List<Store>();
     public IEnumerable<Debt> Debts { get; set; } =  new List<Debt>();
     public IEnumerable<RePayment> RePayments { get; set; } =  new List<RePayment>();
}