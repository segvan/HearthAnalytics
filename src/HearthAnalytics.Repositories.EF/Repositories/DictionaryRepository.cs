using HearthAnalytics.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace HearthAnalytics.Repositories.EF.Repositories
{
    public abstract class DictionaryRepository<T> : IDictionaryRepository<T> where T : class
    {
        public virtual HearthAnalyticsDBContext DBContext { get; }

        public DictionaryRepository(HearthAnalyticsDBContext dbContext)
        {
            this.DBContext = dbContext;
        }

        public virtual IEnumerable<T> FindAll()
        {
            return this.DBContext.Set<T>().ToList();
        }        
    }
}
