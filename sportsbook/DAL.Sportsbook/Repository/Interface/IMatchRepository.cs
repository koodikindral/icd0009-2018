using DAL.Base.Repository.Interface;
using Domain.Sportsbook;

namespace DAL.Sportsbook.Repository.Interface
{
    public interface IMatchRepository : IBaseRepositoryAsync<Match, int>
    {
        
    }
}