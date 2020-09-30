using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UntitledTechie.Infrastructure.UoW
{
    public class BaseUnitOfWork<TContext> : IUnitOfWork
        where TContext: DbContext
    {
        private readonly TContext _context;
        public BaseUnitOfWork(TContext context)
        {
            _context = context;
        }
        public bool SavaChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                
                throw new System.Exception(ex.Message, ex);
            }
        }

        public async Task<bool> SavaChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                
                throw new System.Exception(ex.Message, ex);
            }
        }
    }
}