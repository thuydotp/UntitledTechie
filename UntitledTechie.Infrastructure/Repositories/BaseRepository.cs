using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UntitledTechie.Infrastructure.Entities;

namespace UntitledTechie.Infrastructure.Repositories
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _entity;
        public BaseRepository(TContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }

        #region SELECT/ GET/ QUERY
        public IQueryable<TEntity> GetAll()
        {
        return _entity.AsNoTracking();
        }

        public IList<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }
        public async Task<IList<TEntity>> GetAllListAsync()
        {
            return await GetAll().ToListAsync();
        }

        public IList<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public async Task<IList<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public TEntity Get(object id)
        {
            return _entity.Find(id);
        }

        public async Task<TEntity> GetAsync(object id)
        {
            return await _entity.FindAsync(id);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(predicate).Single();
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Query(predicate).SingleAsync();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(predicate).SingleOrDefault();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Query(predicate).SingleOrDefaultAsync();
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(predicate).First();
        }

        public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Query(predicate).FirstAsync();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(predicate).FirstOrDefault();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Query(predicate).FirstOrDefaultAsync();
        }


        #endregion

        #region INSERT
        public void Insert(TEntity entity)
        {
            _entity.Add(entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            _entity.AddRange(entities);
        }

        public async Task InsertAsync(IEnumerable<TEntity> entities)
        {
            await _entity.AddRangeAsync(entities);
        }


        #endregion

        #region UPDATE
        public void Update(TEntity entity)
        {
            _entity.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            _entity.UpdateRange(entities);
        }

        #endregion

        #region  DELETE
        public void Delete(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void DeleteById(object id)
        {
            _entity.Remove(Get(id));
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            _entity.RemoveRange(entities);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            IList<TEntity> list = _entity.Where(predicate).ToList();
            _entity.RemoveRange(list);
        }

        #endregion

        #region AGGREGATES

        
        public int Count()
        {
            return GetAll().Count();
        }

        public async Task<int> CountAsync()
        {
            return await GetAll().CountAsync();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(predicate).Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Query(predicate).CountAsync();
        }

        public long CountLong()
        {
            return GetAll().LongCount();
        }

        public async Task<long> CountLongAsync()
        {
            return await GetAll().LongCountAsync();
        }

        public long CountLong(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(predicate).LongCount();
        }

        public async Task<long> CountLongAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Query(predicate).LongCountAsync();
        }

        #endregion
    }
}