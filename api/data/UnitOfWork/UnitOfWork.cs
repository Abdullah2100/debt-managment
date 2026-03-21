
using data.Repository.Implement;
using data.Repository.Interface;

namespace data.UnitOfWork;

public class UnitOfWork(AppDbContext context ) : IUnitOfWork
{
    private readonly AppDbContext _context = context;
    
    public  IUserRepository Users { get; set; } = new UserRepository(context);
    public IEmployeeRepository EmployeeRepository { get; set; } =  new EmployeeRepository(context);
    public IStoreEmployeeUserRepository StoreEmployeeUserRepository { get; set; } = new StoreEmployeeUserRepository(context);
    public IStoreRepository StoreRepository { get; set; } =  new StoreRepository(context);
    public IDebtRepository DebtRepository { get; set; } = new DebtRepository(context);
    public IRePaymentRepository RePaymentRepository { get; set; } = new RePaymentRepository(context);

    public void Dispose()
    {
        _context.Dispose();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}