using data.Repository.Interface;

namespace data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; set; }
    IEmployeeRepository EmployeeRepository { get; set; }
    IStoreEmployeeUserRepository StoreEmployeeUserRepository { get; set; }
    IStoreRepository StoreRepository { get; set; }
    void Save();
}