using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UntitledTechie.Service.DataTranferObjects;

namespace UntitledTechie.Service.Contract
{
    public interface IBaseService<TEntity> where TEntity : BaseDTO
    {
        Task<IList<TEntity>> GetAll();

        // Task<IList<TEntity>> GetAllWithDescendingSort(Expression<Func<TEntity, object>> keySelector);
        // Task<IList<TEntity>> GetAllWithAscendingSort(Expression<Func<TEntity, object>> keySelector);
        // Task<IList<TEntity>> GetByCriteria(Expression<Func<TEntity, bool>> predicate);
        // Task<IList<TEntity>> GetByCriteriaWithDescendingSort(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> keySelector);
        // Task<IList<TEntity>> GetByCriteriaWithAscendingSort(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> keySelector);
        Task<TEntity> GetById(Guid id);
        
    }
}