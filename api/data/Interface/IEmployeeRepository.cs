using data.Entity;

namespace data.Interface;

public interface IEmployeeRepository
{
    Task<bool> IsExistByUserId(Guid userId);
    Task<bool> IsExistById(Guid id);
    
    Task<Employee?> GetEmployeeByUserId(Guid userId);
    Task<Employee?> GetEmployeeById(Guid id);
    
    Task<IEnumerable<Employee>> GetEmployees(Guid storeId,int page,int size);
    Task<IEnumerable<Employee>> GetEmployees(int page,int size);
    
    void  CreateEmployees(Guid storeId,Guid userId,EnPermission permission);
    void  UpdateEmployeesPermission(Employee enEmployee);
    void BlockEmployeesFromStore(Guid id , Guid storeId);
    
    
}