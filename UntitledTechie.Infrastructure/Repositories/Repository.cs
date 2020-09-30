using UntitledTechie.Infrastructure.Data;
using UntitledTechie.Infrastructure.Entities;

namespace UntitledTechie.Infrastructure.Repositories
{
    public class Repository<TEntity> : BaseRepository<TEntity, TechieContext>
        where TEntity : BaseEntity
    {
        public Repository(TechieContext context) : base(context)
        {
            
        }
    }
}