using data.Entity;
using data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace data.Repository.Implement;

public class DebtRepository(AppDbContext context) : IDebtRepository
{
    public async Task AddEntity(Debt entity)
    {
        await context.Debts.AddAsync(entity);
    }

    public async Task UpdateEntity(Debt entity)
    {
        await context.Debts.ExecuteUpdateAsync(value =>
            value.SetProperty(debt => debt.Value, entity.Value)
                .SetProperty(debt => debt.Note, entity.Note)
                .SetProperty(debt => debt.OperatedByStoreEmployeeUserId, entity.OperatedByStoreEmployeeUserId)
                .SetProperty(debt => debt.DebtUserId, entity.DebtUserId)
        );
    }
}