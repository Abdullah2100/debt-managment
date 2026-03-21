using data.Entity;
using data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace data.Repository.Implement;

public class EmployeeRepository(AppDbContext context) : IEmployeeRepository
{
    public async Task<Employee?> GetEmployeeById(Guid id)
    {
        return await context.Employees
            .Include(em => em.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(em => em.Id == id);
    }

    public async Task<Employee?> GetEmployeeByUserId(Guid userId)
    {
        return await context
            .Employees
            .Include(em => em.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(em => em.UserId == userId);
    }

    public async Task<ICollection<Employee>> GetEmployees(int page, int size)
    {
        return await context
            .Employees
            .Include(em => em.User)
            .AsNoTracking()
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }

    public async Task AddEntity(Employee entity)
    {
        await context.Employees.AddAsync(entity);
    }

    public async Task UpdateEntity(Employee entity)
    {
        await context.Employees
            .ExecuteUpdateAsync(value =>
                value.SetProperty(id => entity.UserId, entity.UserId)
                    .SetProperty(id => entity.UpdateAt, entity.UpdateAt)
            );
    }
}