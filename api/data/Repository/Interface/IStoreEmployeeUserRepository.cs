using data.Entity;

namespace data.Repository.Interface;

public interface IStoreEmployeeUserRepository:IRepository<StoreEmployeeUser>
{
    Task<StoreEmployeeUser?> GetStoreEmployeeUserById(Guid id);
    Task<StoreEmployeeUser?> GetStoreEmployeeUserByUserId(Guid userId);
    Task<bool> IsActiveStoreEmployeeUser(Guid id);

    Task<ICollection<Debt>> GetStoreDebts(Guid id,int page,int size);
    Task<ICollection<RePayment>> GetStoreRePayments(Guid id,int page,int size);
    Task<ICollection<Transaction>> GetStoreTransaction(Guid id,int page,int size);
    
}