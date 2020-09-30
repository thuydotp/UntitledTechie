// using System.Linq;
// using System;
// using System.Collections.Generic;
// using System.Linq.Expressions;
// using System.Threading.Tasks;
// using UntitledTechie.Infrastructure.Repositories;
// using UntitledTechie.Service.Contract;
// using Microsoft.EntityFrameworkCore;
// using UntitledTechie.Service.DataTranferObjects;
// using UntitledTechie.Infrastructure.Entities;

// namespace UntitledTechie.Service.Services
// {
//     public class BaseService<TEntity, TDataTranferObject> : IBaseService<TDataTranferObject>
//         where TEntity : BaseEntity
//         where TDataTranferObject: BaseDTO
//     {
//         private readonly IRepository<TEntity> _repository;

//         public BaseService()
//         {
//         }

//         public BaseService(IRepository<TEntity> repository)
//         {
//             _repository = repository;
//         }

//         public Task<IList<TDataTranferObject>> GetAll()
//         {
//             return _repository.GetAllListAsync();
//         }

//         public Task<IList<TDataTranferObject>> GetAllWithAscendingSort(Expression<Func<TDataTranferObject, object>> keySelector)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<IList<TDataTranferObject>> GetAllWithDescendingSort(Expression<Func<TDataTranferObject, object>> keySelector)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<IList<TDataTranferObject>> GetByCriteria(Expression<Func<TDataTranferObject, bool>> predicate)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<IList<TDataTranferObject>> GetByCriteriaWithAscendingSort(Expression<Func<TDataTranferObject, bool>> predicate, Expression<Func<TDataTranferObject, object>> keySelector)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<IList<TDataTranferObject>> GetByCriteriaWithDescendingSort(Expression<Func<TDataTranferObject, bool>> predicate, Expression<Func<TDataTranferObject, object>> keySelector)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<TDataTranferObject> GetById(Guid id)
//         {
//             throw new NotImplementedException();
//         }


//         // public async Task<IList<TEntity>> GetAll()
//         // {
//         //     return await _repository.GetAllListAsync();
//         // }

//         // public async Task<IList<TEntity>> GetAllWithAscendingSort(Expression<Func<TEntity, object>> keySelector)
//         // {
//         //     return await _repository.GetAll().OrderBy(keySelector).ToListAsync();
//         // }

//         // public async Task<IList<TEntity>> GetAllWithDescendingSort(Expression<Func<TEntity, object>> keySelector)
//         // {
//         //     return await _repository.GetAll().OrderByDescending(keySelector).ToListAsync();
//         // }

//         // public async Task<IList<TEntity>> GetByCriteria(Expression<Func<TEntity, bool>> predicate)
//         // {
//         //     return await _repository.GetAll().Where(predicate).ToListAsync();
//         // }

//         // public async Task<IList<TEntity>> GetByCriteriaWithAscendingSort(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> keySelector)
//         // {
//         //     return await _repository.GetAll().Where(predicate).OrderBy(keySelector).ToListAsync();
//         // }

//         // public async Task<IList<TEntity>> GetByCriteriaWithDescendingSort(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> keySelector)
//         // {
//         //     return await _repository.GetAll().Where(predicate).OrderByDescending(keySelector).ToListAsync();
//         // }

//         // public Task<TEntity> GetById(Guid id)
//         // {
//         //     throw new NotImplementedException();
//         // }


//     }
// }