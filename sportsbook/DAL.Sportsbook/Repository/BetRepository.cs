using DAL.Base.Repository;
using DAL.Sportsbook.Repository.Interface;
using Domain.Sportsbook;

namespace DAL.Sportsbook.Repository
{
    public class BetRepository: BaseRepositoryAsync<Bet>, IBetRepository
    {
        public BetRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}