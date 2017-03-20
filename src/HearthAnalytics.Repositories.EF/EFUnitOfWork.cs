using HearthAnalytics.Infrastructure;

namespace HearthAnalytics.Repositories.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private HearthAnalyticsDBContext _dbContext;

        public EFUnitOfWork(HearthAnalyticsDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Complete()
        {
            this._dbContext.SaveChanges();
        }
    }
}
