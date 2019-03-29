using System;
using System.Collections.Generic;
using DAL.Base.UnitOfWork;
using DAL.Wallet.Repository;
using DAL.Wallet.Repository.Interface;
using DAL.Wallet.UnitOfWork.Interface;

namespace DAL.Wallet.UnitOfWork
{
    public class AppUnitOfWork : BaseUnitOfWork, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
        }

        private IAccountRepository _accountRepository;        
        public IAccountRepository Accounts => 
            _accountRepository ?? (_accountRepository = new AccountRepository((AppDbContext) UOWDbContext));

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