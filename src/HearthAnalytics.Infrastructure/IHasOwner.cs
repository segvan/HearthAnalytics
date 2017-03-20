namespace HearthAnalytics.Infrastructure
{
    public interface IHasOwner<T>
    {
        T OwnerUserId { get; set; }
    }
}
