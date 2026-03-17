using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Entity;

namespace data.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeById(Guid id);
        Task<Employee?> GetEmployeeByUserId(Guid userId);
        Task<ICollection<Employee>> GetEmployees(int  page,int size);
    }
}