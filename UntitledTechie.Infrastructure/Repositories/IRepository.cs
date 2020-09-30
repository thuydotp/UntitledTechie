using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UntitledTechie.Infrastructure.Entities;

namespace UntitledTechie.Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {

        #region SELECT/ GET/ QUERY

        IQueryable<TEntity> GetAll();
        IList<TEntity> GetAllList();
        Task<IList<TEntity>> GetAllListAsync();

        IList<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(object id);
        Task<TEntity> GetAsync(object id);

        TEntity Single(Expression<Func<TEntity,bool>> predicate);
        Task<TEntity> SingleAsync(Expression<Func<TEntity,bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity,bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity,bool>> predicate);

        TEntity First(Expression<Func<TEntity,bool>> predicate);
        Task<TEntity> FirstAsync(Expression<Func<TEntity,bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity,bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity,bool>> predicate);

        #endregion
    
        #region INSERT
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);
        Task InsertAsync(IEnumerable<TEntity> entities);

        #endregion
    
        #region UPDATE
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);

        #endregion

        #region  DELETE
        void Delete(TEntity entity);
        void DeleteById(object id);

        void Delete(IEnumerable<TEntity> entities);
        void Delete(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region AGGREGATES
        int Count();
        Task<int> CountAsync();
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        long CountLong();
        Task<long> CountLongAsync();
        long CountLong(Expression<Func<TEntity, bool>> predicate);
        Task<long> CountLongAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }

}