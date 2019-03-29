using DAL.Base.Repository;
using DAL.Sportsbook.Repository.Interface;
using Domain.Sportsbook;

namespace DAL.Sportsbook.Repository
{
    public class OddsRepository: BaseRepositoryAsync<Odds>, IOddsRepository
    {
        public OddsRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}