using System;

namespace HearthAnalytics.Repositories.EF.Seed
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SeedOrderAttribute : Attribute
    {
        public int OrderNumber { get; private set; }
        public SeedOrderAttribute(int orderNumber)
        {
            OrderNumber = orderNumber;
        }
    }
}
