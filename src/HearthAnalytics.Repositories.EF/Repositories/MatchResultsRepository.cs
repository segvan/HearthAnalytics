using HearthAnalytics.Model;
using HearthAnalytics.Model.Repositories;

namespace HearthAnalytics.Repositories.EF.Repositories
{
    public class MatchResultsRepository : DictionaryRepository<MatchResult>, IMatchResultsRepository
    {
        public MatchResultsRepository(HearthAnalyticsDBContext dbContext) : base(dbContext)
        {
        }
    }
}
