using data.Entity;

namespace data.Repository.Interface;

public interface IUserRepository
{
    Task<User?> GetUser(Guid id);    
    Task<User?> GetUserByPhone(string phone);
    
    Task<ICollection<Debt>> GetMyDebts(Guid userId,int page,int size);
    Task<ICollection<RePayment>> GetMyRePayments(Guid userId,int page,int size);
    Task<ICollection<User>> GetUsers(int page,int size);
}