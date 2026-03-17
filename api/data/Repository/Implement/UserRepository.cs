using data.Entity;
using data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace data.Repository.Implement;

public class UserRepository(AppDbContext context):IUserRepository
{
    public async Task<User?> GetUser(Guid id)
    {
        return await context.Users
            .Include(us=>us.Employee)
            .Include(us=>us.StoreEmployeeUser)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetUserByPhone(string phone)
    {
        return await context.Users
            .Include(us=>us.Employee)
            .Include(us=>us.StoreEmployeeUser)
            .FirstOrDefaultAsync(u => u.Phone == phone);
    }

     public async Task<ICollection<Debt>> GetMyDebts(Guid userId,int page,int size)
     {
         return await context.Debts
             . Where(deb => deb.DebtUserId == userId)
             .Take(size)
             .Skip((page - 1) * size)
             .ToListAsync();
     }

    public async Task<ICollection<RePayment>> GetMyRePayments(Guid userId,int page,int size)
    {
        return await context.RePayments
            . Where(repay => repay.RePaymentUserId == userId)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }
}