using data.Entity;
using data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace data.Repository.Implement;

public class StoreEmployeeUserRepository(AppDbContext context) : IStoreEmployeeUserRepository
{
    public async Task AddEntity(Entity.StoreEmployeeUser entity)
    {
        await context.StoreEmployeeUsers.AddAsync(entity);
    }

    public async Task UpdateEntity(StoreEmployeeUser entity)
    {
        await context.StoreEmployeeUsers
            .ExecuteUpdateAsync(value =>
                value
                    .SetProperty(seu => seu.IsActive, entity.IsActive)
                    .SetProperty(seu => seu.IsMainStoreAdmin, entity.IsMainStoreAdmin)
                    .SetProperty(seu => seu.Permission, entity.Permission)
                    .SetProperty(seu => seu.UserId, entity.UserId)
                    .SetProperty(seu => seu.StoreId, entity.StoreId)
            );
    }


    public async Task<Entity.StoreEmployeeUser?> GetStoreEmployeeUserById(Guid id)
    {
        return await context.StoreEmployeeUsers
            .Include(seu => seu.Store)
            .Include(seu => seu.User)
            .Include(seu => seu.StoreDebt)
            .Include(seu => seu.StoreRepayment)
            .Include(seu => seu.StoreOperationTransactions)
            .FirstOrDefaultAsync(seu => seu.Id == id);
    }

    public async Task<StoreEmployeeUser?> GetStoreEmployeeUserByUserId(Guid userId)
    {
        return await context.StoreEmployeeUsers
            .Include(seu => seu.Store)
            .Include(seu => seu.User)
            .Include(seu => seu.StoreDebt)
            .Include(seu => seu.StoreRepayment)
            .Include(seu => seu.StoreOperationTransactions)
            .FirstOrDefaultAsync(seu => seu.UserId == userId);
    }

    public async Task<bool> IsActiveStoreEmployeeUser(Guid id)
    {
        return await context.StoreEmployeeUsers.AnyAsync(seu => seu.Id == id && seu.IsActive);
    }

    public async Task<ICollection<Debt>> GetStoreDebts(Guid storeId, int page, int size)
    {
        return await context.Debts
            .Include(deb => deb.StoreEmployeeUser)
            .Include(deb => deb.Store)
            .Include(deb => deb.DebtBy)
            .AsNoTracking()
            .Where(deb => deb.StoreId == storeId)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }

    public async Task<ICollection<RePayment>> GetStoreRePayments(Guid storeId, int page, int size)
    {
        return await context.RePayments
            .Include(repay => repay.StoreEmployeeUser)
            .Include(repay => repay.Store)
            .Include(repay => repay.RePaymentBy)
            .AsNoTracking()
            .Where(repay => repay.StoreId == storeId)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }

    public async Task<ICollection<Transaction>> GetStoreTransaction(Guid storeId, int page, int size)
    {
        return await context.StoreTransactions
            .Include(repay => repay.StoreEmployeeUser)
            .Include(repay => repay.Store)
            .AsNoTracking()
            .Where(repay => repay.StoreId == storeId)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }
}