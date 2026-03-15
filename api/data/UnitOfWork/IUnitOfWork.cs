
namespace data.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
    
    void  Save();
    
}