using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UntitledTechie.Service.DataTranferObjects;

namespace UntitledTechie.Service.Contract
{
    public interface IAccountService
    {
        #region CRUD
        Task<bool> Create(Account newEntity);
        Task<bool> Update(Account updatedEntity);
        Task<bool> UpdateRange(IList<Account> updatedEntities);
        Task<bool> DeleteById(Guid id);
        Task<bool> Delete(Account deletedEntity);
        Task<bool> DeleteRange(IList<Account> deletedEntities);

        #endregion
        
        int CountFollowers();
        int CountFollowees();
        IEnumerable<Account> GetFollowers();
        IEnumerable<Account> GetFollowees();
    }
}