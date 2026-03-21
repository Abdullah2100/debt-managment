using data.Entity;
using data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace data.Repository.Implement;

public class RePaymentRepository(AppDbContext context) : IRePaymentRepository
{
    public async Task AddEntity(RePayment entity)
    {
       await context.RePayments.AddAsync(entity);
    }

    public async Task UpdateEntity(RePayment entity)
    {
        await context.RePayments.ExecuteUpdateAsync(value =>
            value.SetProperty(rep => rep.Value, entity.Value)
                .SetProperty(rep => rep.Note, entity.Note)
                .SetProperty(rep => rep.OperatedByStoreEmployeeUserId, entity.OperatedByStoreEmployeeUserId)
                .SetProperty(rep => rep.RePaymentUserId, entity.RePaymentUserId)
        );
    }
}