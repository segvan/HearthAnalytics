using HearthAnalytics.Infrastructure;
using System;

namespace HearthAnalytics.Model.Repositories
{
    public interface IMatchesRepository : IRepository<Match, Guid>
    {
    }
}
