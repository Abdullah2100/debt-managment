using data.Entity;
using data.Interface;
using Microsoft.EntityFrameworkCore;

namespace data.Repository;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<bool> IsExistByPhone(string phone)
    {
        return await context.Users.AnyAsync(user => user.Phone == phone);
    }

    public Task<bool> IsExistByPhone(string phone, string fullName)
    {
        return context.Users.AnyAsync(user => user.Phone == phone && user.FullName == fullName);
    }

    public void CreateUser(string phone, string fullName, string password)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Phone = phone,
            FullName = fullName,
            CreatedAt = DateTime.Now,
        };
        context.Users.AddAsync(user);
    }

    public void UpdateUser(User user)
    {
        context.Users.Update(user);
    }

    public Task<User?> GetUser(Guid id)
    {
        return context.Users.FirstOrDefaultAsync(us => us.Id == id);
    }
}