
using data.Repository.Interface;

namespace data.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
 
    IUserRepository Users { get; }
    void  Save();
    
}