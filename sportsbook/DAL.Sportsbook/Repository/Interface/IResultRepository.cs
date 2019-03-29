using DAL.Base.Repository;
using Domain.Sportsbook;

namespace DAL.Sportsbook.Repository.Interface
{
    public interface IResultRepository : IBaseRepositoryAsync<Result, int>
    {
        
    }
}