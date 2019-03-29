using DAL.Base.Repository;
using DAL.Sportsbook.Repository.Interface;
using Domain.Sportsbook;

namespace DAL.Sportsbook.Repository
{
    public class SiteRepository: BaseRepositoryAsync<Site>, ISiteRepository
    {
        public SiteRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}