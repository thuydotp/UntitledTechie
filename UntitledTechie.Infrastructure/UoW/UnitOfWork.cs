using UntitledTechie.Infrastructure.Data;

namespace UntitledTechie.Infrastructure.UoW
{
    public class UnitOfWork : BaseUnitOfWork<TechieContext>
    {
        public UnitOfWork(TechieContext context) : base(context)
        {
        }
    }
}