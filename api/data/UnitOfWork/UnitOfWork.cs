using data.Interface;
using data.Repository;

namespace data.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public void Dispose()
    {
        _context.Dispose();
    }

    public IUserRepository UserRepository { get; } = new UserRepository(context);
    public IEmployeeRepository EmployeeRepository { get; } = new  EmployeeRepository(context);
    public IRePaymentRepository RePaymentRepository { get; } = new RePaymentRepository(context);
    public IStoreRepository StoreRepository { get; } = new  StoreRepository(context);
    public IDebtsRepository DebtsRepository { get; } = new   DebtsRepository(context);

    public void Save()
    {
        _context.SaveChanges();
    }
}