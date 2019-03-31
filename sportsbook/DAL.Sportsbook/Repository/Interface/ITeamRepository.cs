using DAL.Base.Repository.Interface;
using Domain.Sportsbook;

namespace DAL.Sportsbook.Repository.Interface
{
    public interface ITeamRepository : IBaseRepositoryAsync<Team, int>
    {
        
    }
}