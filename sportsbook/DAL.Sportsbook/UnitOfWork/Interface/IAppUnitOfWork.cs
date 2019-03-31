using DAL.Base.UnitOfWork.Interface;
using DAL.Sportsbook.Repository.Interface;

namespace DAL.Sportsbook.UnitOfWork.Interface
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IBetRepository Bets { get; }
        ICategoryRepository Categories { get; }
        IMatchRepository Matches { get; }
        IOddsRepository Odds { get; }
        IResultRepository Results { get; }
        ISiteRepository Sites { get; }
        ITeamRepository Teams { get; }
    }
}