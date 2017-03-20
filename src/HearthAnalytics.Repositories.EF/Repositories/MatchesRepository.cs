using HearthAnalytics.Model;
using HearthAnalytics.Model.Repositories;
using System;

namespace HearthAnalytics.Repositories.EF.Repositories
{
    public class MatchesRepository : Repository<Match, Guid>, IMatchesRepository
    {
        public MatchesRepository(HearthAnalyticsDBContext dbContext) : base(dbContext)
        {
        }
    }
}
