using System.Threading.Tasks;

namespace DAL.Base.UnitOfWork.Interface
{
    public interface IBaseUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }

}