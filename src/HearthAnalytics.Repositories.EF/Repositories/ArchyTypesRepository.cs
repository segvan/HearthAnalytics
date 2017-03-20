using HearthAnalytics.Model;
using HearthAnalytics.Model.Repositories;

namespace HearthAnalytics.Repositories.EF.Repositories
{
    public class ArchyTypesRepository : Repository<ArchyType, int>, IArchyTypesRepository
    {
        public ArchyTypesRepository(HearthAnalyticsDBContext dbContext) : base(dbContext)
        {
        }
    }
}
