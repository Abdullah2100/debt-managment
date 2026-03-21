using data.Entity;

namespace data.Repository.Interface;

public interface IStoreRepository:IRepository<Store>
{
 Task<Store?> GetStoreById(Guid id);
 Task<Store?> GetStoreByName(string storeName);
 
 Task<bool> IsStoreBlocked(Guid id);

 Task<ICollection<BlockedStoreEmployeeUser>> GetStoreBlockedEmployeeUsers(Guid id, int page, int size);
 Task<ICollection<StoreEmployeeUser>> GetStoreEmployeeUsers(Guid id, int page, int size);

 Task<ICollection<Debt>> GetStoreDebts(Guid id, int page, int size);
 Task<ICollection<RePayment>> GetStoreRePayments(Guid id, int page, int size);
 Task<ICollection<Transaction>> GetStoreTransactions(Guid id, int page, int size);
}