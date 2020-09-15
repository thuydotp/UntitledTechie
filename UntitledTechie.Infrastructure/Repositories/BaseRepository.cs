using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UntitledTechie.Infrastructure.Entities;
using UntitledTechie.Infrastructure.Repositories.Contract;

namespace UntitledTechie.Infrastructure.Repositories
{
    public class BaseRepository<TEntity, TKey, TContext> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TContext : DbContext
    {
        int IRepository<TEntity, TKey>.Count()
        {
            throw new NotImplementedException();
        }

        int IRepository<TEntity, TKey>.Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<TEntity, TKey>.CountAsync()
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<TEntity, TKey>.CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        long IRepository<TEntity, TKey>.CountLong()
        {
            throw new NotImplementedException();
        }

        long IRepository<TEntity, TKey>.CountLong(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<long> IRepository<TEntity, TKey>.CountLongAsync()
        {
            throw new NotImplementedException();
        }

        Task<long> IRepository<TEntity, TKey>.CountLongAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity, TKey>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity, TKey>.Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity, TKey>.Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity, TKey>.DeleteById(TKey id)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity, TKey>.First(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepository<TEntity, TKey>.FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity, TKey>.FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepository<TEntity, TKey>.FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity, TKey>.Get(TKey id)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IRepository<TEntity, TKey>.GetAll()
        {
            throw new NotImplementedException();
        }

        IList<TEntity> IRepository<TEntity, TKey>.GetAllList()
        {
            throw new NotImplementedException();
        }

        IList<TEntity> IRepository<TEntity, TKey>.GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<List<TEntity>> IRepository<TEntity, TKey>.GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        Task<IList<TEntity>> IRepository<TEntity, TKey>.GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepository<TEntity, TKey>.GetAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity, TKey>.Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity, TKey>.Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        Task IRepository<TEntity, TKey>.InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<TEntity, TKey>.InsertAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IRepository<TEntity, TKey>.Query(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity, TKey>.Single(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepository<TEntity, TKey>.SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity, TKey>.SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepository<TEntity, TKey>.SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity, TKey>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity, TKey>.Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}