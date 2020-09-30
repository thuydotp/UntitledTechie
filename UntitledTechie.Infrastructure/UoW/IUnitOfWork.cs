using System.Threading.Tasks;

namespace UntitledTechie.Infrastructure.UoW
{
    public interface IUnitOfWork
    {
        bool SavaChanges();
        Task<bool> SavaChangesAsync();
    }
}