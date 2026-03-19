
using data.Repository.Implement;
using data.Repository.Interface;

namespace data.UnitOfWork;

public class UnitOfWork(AppDbContext context ) : IUnitOfWork
{
    private readonly AppDbContext _context = context;
    
    public  IUserRepository Users { get; set; } = new UserRepository(context);
    public IEmployeeRepository EmployeeRepository { get; set; } =  new EmployeeRepository(context);
    public IStoreEmployeeUserRepository StoreEmployeeUserRepository { get; set; } = new StoreEmployeeUserRepository(context);

    public void Dispose()
    {
        _context.Dispose();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}