using data.Entity;
using data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace data.Repository.Implement;

public class StoreRepository(AppDbContext context) : IStoreRepository
{
    public async Task AddEntity(Store entity)
    {
        await context.Stores.AddAsync(entity);
    }

    public async Task UpdateEntity(Store entity)
    {
        await context.Stores
            .ExecuteUpdateAsync(value =>
                value.SetProperty(store => store.StoreName, entity.StoreName)
                    .SetProperty(store => store.IsBlocked, entity.IsBlocked)
                    .SetProperty(store => store.UpdateAt, entity.UpdateAt)
            );
    }

    public async Task<Store?> GetStoreById(Guid id)
    {
        return await context.Stores
            .FindAsync(id);
    }

    public async Task<Store?> GetStoreByName(string storeName)
    {
        return await context.Stores
            .FirstOrDefaultAsync(store => store.StoreName == storeName);
    }

    public async Task<bool> IsStoreBlocked(Guid id)
    {
        return await context.Stores
            .AnyAsync(store => store.Id == id && store.IsBlocked == true);
    }

    public async Task<ICollection<BlockedStoreEmployeeUser>> GetStoreBlockedEmployeeUsers(Guid id, int page, int size)
    {
        return await context.StoreBlockedEmployee
            .Include(sbe => sbe.User)
            .Include(sbe => sbe.Store)
            .AsNoTracking()
            .Where(sbe => sbe.StoreId == id)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }

    public async Task<ICollection<StoreEmployeeUser>> GetStoreEmployeeUsers(Guid id, int page, int size)
    {
        return await context.StoreEmployeeUsers
            .Include(seu=>seu.User)
            .Include(seu=>seu.Store)
            .AsNoTracking()
            .Where(seu => seu.StoreId == id)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }

    public async Task<ICollection<Debt>> GetStoreDebts(Guid id, int page, int size)
    {
        return await context.Debts
            .Include(deb => deb.StoreEmployeeUser)
            .Include(deb => deb.Store)
            .Include(deb => deb.DebtBy)
            .AsNoTracking()
            .Where(deb => deb.StoreId == id)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }

    public async Task<ICollection<RePayment>> GetStoreRePayments(Guid id, int page, int size)
    {
        return await context.RePayments
            .Include(rep => rep.StoreEmployeeUser)
            .Include(rep => rep.Store)
            .Include(rep => rep.RePaymentBy)
            .AsNoTracking()
            .Where(rep => rep.StoreId == id)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }

    public async Task<ICollection<Transaction>> GetStoreTransactions(Guid id, int page, int size)
    {
        return await context.Transactions
            .Include(tr => tr.StoreEmployeeUser)
            .Include(tr => tr.Store)
            .AsNoTracking()
            .Where(tr => tr.StoreId == id)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }
}