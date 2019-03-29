using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.UnitOfWork
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        protected readonly DbContext UOWDbContext;

        public BaseUnitOfWork(DbContext dbContext)
        {
            UOWDbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await UOWDbContext.SaveChangesAsync();
        }
    }

}