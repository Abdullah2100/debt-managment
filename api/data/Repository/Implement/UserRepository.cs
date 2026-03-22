using data.Entity;
using data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace data.Repository.Implement;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetUser(Guid id)
    {
        return await context.Users
            .Include(us => us.Employee)
            .Include(us => us.StoreEmployeeUser)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetUserByPhone(string phone)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Phone == phone);
    }

    public async Task<ICollection<Debt>> GetMyDebts(Guid userId, int page, int size)
    {
        return await context.Debts
            .Include(deb => deb.StoreEmployeeUser)
            .Include(deb => deb.Store)
            .Include(deb => deb.DebtBy)
            .AsNoTracking()
            .Where(deb => deb.DebtUserId == userId)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }

    public async Task<ICollection<RePayment>> GetMyRePayments(Guid userId, int page, int size)
    {
        return await context.RePayments
            .Include(repay => repay.StoreEmployeeUser)
            .Include(repay => repay.Store)
            .Include(repay => repay.RePaymentBy)
            .AsNoTracking()
            .Where(repay => repay.RePaymentUserId == userId)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }

    public async Task<ICollection<User>> GetUsers(int page, int size)
    {
        return await context.Users
            .Include(us => us.StoreEmployeeUser)
            .Include(us => us.Employee)
            .AsNoTracking()
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }
    
    public async Task AddEntity(User entity)
    {
        await context.Users.AddAsync(entity);
    }

    public async Task UpdateEntity(User entity)
    {
        await   context.Users
            .ExecuteUpdateAsync(value=>
                value
                    .SetProperty(user=> user.FullName, entity.FullName)
                    .SetProperty(user=> user.Email, entity.Email)
                    .SetProperty(user=>user.UpdateAt,entity.UpdateAt)
                    .SetProperty(user=>user.Password,entity.Password)
                   );
    }
}