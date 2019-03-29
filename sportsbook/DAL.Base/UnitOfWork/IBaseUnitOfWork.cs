using System.Threading.Tasks;

namespace DAL.Base.UnitOfWork
{
    public interface IBaseUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }

}