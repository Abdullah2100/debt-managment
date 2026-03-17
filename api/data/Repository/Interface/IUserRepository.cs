using data.Entity;

namespace data.Repository.Interface;

public interface IUserRepository
{
    Task<User?> GetUser(Guid id);    
    Task<User?> GetUserByPhone(string phone);
    
    Task<StoreEmployeeUser> GetStoreEmployeeUserById(Guid storeEmployeeUserId);
    Task<StoreEmployeeUser> GetStoreEmployeeUserByUserId(Guid userId);
    
    Task<ICollection<Debt>> GetMyDebts(Guid userId);
    Task<ICollection<RePayment>> GetMyRePayments(Guid userId);
    
}