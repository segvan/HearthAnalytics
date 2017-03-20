using HearthAnalytics.Model;
using HearthAnalytics.Model.Repositories;

namespace HearthAnalytics.Repositories.EF.Repositories
{
    public class ClassTypesRepository : DictionaryRepository<ClassType>, IClassTypesRepository
    {
        public ClassTypesRepository(HearthAnalyticsDBContext dbContext) : base(dbContext)
        {
        }
    }
}
