using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UntitledTechie.Infrastructure.Entities;
using UntitledTechie.Infrastructure.Repositories;
using UntitledTechie.Service.Contract;
using UntitledTechie.Service.DataTranferObjects;

namespace UntitledTechie.Service.Services
{
    public class AccountService : IBaseService<Account>
    {
        private readonly IRepository<AccountEntity> _accountRepository;
        public AccountService(IRepository<AccountEntity> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IList<Account>> GetAll()
        {
            var list = await _accountRepository.GetAllListAsync();
            return Mapping(list);
        }

        // public async Task<IList<Account>> GetByCriteria(Expression<Func<Account, bool>> predicate)
        // {
        //     var list = await _accountRepository.GetAllListAsync(predicate);
        // }

        public Task<Account> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        private IList<Account> Mapping(IEnumerable<AccountEntity> entities)
        {
            return entities.Select(x => Mapping(x)).ToList();
        }

        private Account Mapping(AccountEntity entity)
        {
            return new Account()
            {
                Id = entity.Id,
                AvatarImageId = entity.AvatarImageId,
                Username = entity.Username,
            };
        }
    }
}