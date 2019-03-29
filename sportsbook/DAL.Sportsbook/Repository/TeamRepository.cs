using DAL.Base.Repository;
using DAL.Sportsbook.Repository.Interface;
using Domain.Sportsbook;

namespace DAL.Sportsbook.Repository
{
    public class TeamRepository: BaseRepositoryAsync<Team>, ITeamRepository
    {
        public TeamRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}