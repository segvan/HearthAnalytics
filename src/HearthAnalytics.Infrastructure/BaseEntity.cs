namespace HearthAnalytics.Infrastructure
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }

        public bool IsTransient
        {
            get
            {
                return Id.Equals(default(T));
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity<T>))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var item = (BaseEntity<T>)obj;

            if (item.IsTransient || IsTransient)
            {
                return false;
            }
            return item.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (!IsTransient)
            {
                return Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
            }

            return base.GetHashCode();
        }
    }
}
