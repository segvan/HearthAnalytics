using System.Collections.Generic;

namespace HearthAnalytics.Infrastructure
{
    public interface IDictionaryRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
    }
}
