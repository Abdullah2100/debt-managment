using data.Entity;

namespace data.Interface;

public interface IUserRepository
{
    Task<Boolean> IsExistByPhone(string phone);
    Task<Boolean> IsExistByPhone(string phone, string fullName);
    void CreateUser(string phone, string fullName, string password);
    void UpdateUser(User user );
}