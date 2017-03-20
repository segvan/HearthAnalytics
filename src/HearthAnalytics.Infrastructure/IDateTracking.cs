using System;

namespace HearthAnalytics.Infrastructure
{
    public interface IDateTracking
    {
        DateTime Created { get; set; }

        DateTime Modified { get; set; }
    }
}
