using DAL.Base.Repository;
using DAL.Sportsbook.Repository.Interface;
using Domain.Sportsbook;

namespace DAL.Sportsbook.Repository
{
    public class MatchRepository: BaseRepositoryAsync<Match>, IMatchRepository
    {
        public MatchRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}