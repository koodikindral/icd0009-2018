using DAL.Base.Repository;
using DAL.Sportsbook.Repository.Interface;
using Domain.Sportsbook;

namespace DAL.Sportsbook.Repository
{
    public class ResultRepository: BaseRepositoryAsync<Result>, IResultRepository
    {
        public ResultRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}