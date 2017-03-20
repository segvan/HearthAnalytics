namespace HearthAnalytics.Infrastructure
{
    public interface IUnitOfWork
    {
        void Complete();
    }
}
