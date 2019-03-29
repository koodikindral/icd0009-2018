using System;
using System.Collections.Generic;
using DAL.Base.UnitOfWork;
using DAL.Sportsbook.Repository;
using DAL.Sportsbook.Repository.Interface;
using DAL.Sportsbook.UnitOfWork.Interface;

namespace DAL.Sportsbook.UnitOfWork
{
    public class AppUnitOfWork : BaseUnitOfWork, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
        }
        
        private IBetRepository _betRepository;        
        public IBetRepository Bets => 
            _betRepository ?? (_betRepository = new BetRepository((AppDbContext) UOWDbContext));
        
        private ICategoryRepository _categoryRepository;        
        public ICategoryRepository Categories => 
            _categoryRepository ?? (_categoryRepository = new CategoryRepository((AppDbContext) UOWDbContext));

        private IMatchRepository _matchRepository;        
        public IMatchRepository Matches => 
            _matchRepository ?? (_matchRepository = new MatchRepository((AppDbContext) UOWDbContext));
        
        private IOddsRepository _oddsRepository;        
        public IOddsRepository Odds => 
            _oddsRepository ?? (_oddsRepository = new OddsRepository((AppDbContext) UOWDbContext));
  
        private IResultRepository _resultRepository;        
        public IResultRepository Results => 
            _resultRepository ?? (_resultRepository = new ResultRepository((AppDbContext) UOWDbContext));
        
        private ISiteRepository _siteRepository;        
        public ISiteRepository Sites => 
            _siteRepository ?? (_siteRepository = new SiteRepository((AppDbContext) UOWDbContext));
     
        private ITeamRepository _teamRepository;        
        public ITeamRepository Teams => 
            _teamRepository ?? (_teamRepository = new TeamRepository((AppDbContext) UOWDbContext));
        
        // repo factory
        private readonly Dictionary<Type, object> _repositoryCache  = new Dictionary<Type, object>();
        private TRepository GetOrCreateRepository<TRepository>(Func<AppDbContext, TRepository> repoCreationMethod)  
        {

            if (_repositoryCache.ContainsKey(typeof(TRepository)))
            {
                return (TRepository) _repositoryCache[typeof(TRepository)];
            }

            // we didnt find the correct repo, create it
            object repo = repoCreationMethod((AppDbContext) UOWDbContext);
       
            _repositoryCache[typeof(TRepository)] = repo;
            return (TRepository) repo;
        }

    }
}