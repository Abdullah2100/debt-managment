using data.Entity;

namespace data.Interface;

public interface IUserRepository
{
    Task<bool> IsExistByPhone(string phone);
    Task<bool> IsExistByPhone(string phone, string fullName);
    void CreateUser(string phone, string fullName, string password);
    void UpdateUser(User user );
    Task<User?> GetUser(Guid id);
}