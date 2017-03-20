using HearthAnalytics.Model;
using HearthAnalytics.Model.Repositories;
using System;

namespace HearthAnalytics.Repositories.EF.Repositories
{
    public class DecksRepository : Repository<Deck, Guid>, IDecksRepository
    {
        public DecksRepository(HearthAnalyticsDBContext dbContext) : base(dbContext)
        {
        }
    }
}
