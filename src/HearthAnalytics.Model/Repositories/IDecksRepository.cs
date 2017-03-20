using HearthAnalytics.Infrastructure;
using System;

namespace HearthAnalytics.Model.Repositories
{
    public interface IDecksRepository : IRepository<Deck, Guid>
    {
    }
}
