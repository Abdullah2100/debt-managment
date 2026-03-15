
namespace data.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public void Dispose()
    {
        _context.Dispose();
    }


    public void Save()
    {
        _context.SaveChanges();
    }
}