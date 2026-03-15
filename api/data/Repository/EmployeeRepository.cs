using data.Entity;
using data.Interface;
using Microsoft.EntityFrameworkCore;

namespace data.Repository;

public class EmployeeRepository(AppDbContext context):IEmployeeRepository
{
    public async Task<bool> IsExistByUserId(Guid userId)
    {
        return await context.Employees.AnyAsync(em => em.UserId == userId);
    }

    public async Task<bool> IsExistById(Guid id)
    {
        return await context.Employees.AnyAsync(em => em.Id == id);
    }

    public async Task<Employee?> GetEmployeeByUserId(Guid userId)
    {
        return await context.Employees.FirstOrDefaultAsync(em => em.UserId == userId);

    }

    public async Task<Employee?> GetEmployeeById(Guid id)
    {
        return await context.Employees.FirstOrDefaultAsync(em => em.Id == id);
    }

    public async Task<IEnumerable<Employee>> GetEmployees(Guid storeId, int page, int size)
    {
        return await context.Employees
            .Where(em => em.StoreId == storeId)
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }

    public async Task<IEnumerable<Employee>> GetEmployees(int page, int size)
    {
        return await context.Employees
            .Take(size)
            .Skip((page - 1) * size)
            .ToListAsync();
    }


    public void CreateEmployees(Guid storeId, Guid userId,EnPermission permission)
    {
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            StoreId = storeId,
            Permission = permission
        };
        context.Employees.Add(employee);
    }

    public void UpdateEmployeesPermission(Employee enEmployee)
    {
        context.Employees.Update(enEmployee);
    }

    public void  BlockEmployeesFromStore(Guid id , Guid storeId)
    {
        var blockedEmpoyee = new EmployeeBlockedByStore
        {
            Id = Guid.NewGuid(),
            EmployeeId = id,
            StoreId =storeId 
        };
        context.StoreBlockedEmployee.Add(blockedEmpoyee);
    }
}