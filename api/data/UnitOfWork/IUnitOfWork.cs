using data.Repository.Interface;

namespace data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; set; }
    IEmployeeRepository EmployeeRepository { get; set; }
    IStoreEmployeeUserRepository StoreEmployeeUserRepository { get; set; }
    IStoreRepository StoreRepository { get; set; }
    IDebtRepository DebtRepository { get; set; }
    IRePaymentRepository RePaymentRepository { get; set; }
    void Save();
}