using data.Interface;

namespace data.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
    public IUserRepository UserRepository { get; }
    public IEmployeeRepository EmployeeRepository { get; }
    public IRePaymentRepository RePaymentRepository { get; }
    public IStoreRepository StoreRepository { get; }
    public IDebtsRepository DebtsRepository { get; }
    
    void  Save();
    
}