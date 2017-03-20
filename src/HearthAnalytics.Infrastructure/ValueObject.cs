using System;
using System.Linq;
using System.Reflection;

namespace HearthAnalytics.Infrastructure
{
    public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        public bool Equals(T other)
        {
            if ((object)other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            //compare all public properties
            PropertyInfo[] publicProperties = GetType().GetProperties();

            if (publicProperties.Any())
            {
                return publicProperties.All(p => CheckValue(p, other));
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if ((object)obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;

            }
            var item = obj as ValueObject<T>;

            if ((object)item != null)
            {
                return Equals((T)item);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 31;
            bool changeMultiplier = false;
            int index = 1;

            //compare all public properties
            PropertyInfo[] publicProperties = this.GetType().GetProperties();

            if (publicProperties.Any())
            {
                foreach (var item in publicProperties)
                {
                    object value = item.GetValue(this, null);

                    if ((object)value != null)
                    {
                        hashCode = hashCode * ((changeMultiplier) ? 59 : 114) + value.GetHashCode();
                        changeMultiplier = !changeMultiplier;
                    }
                    else
                    {
                        hashCode = hashCode ^ (index * 13);//only for support {"a",null,null,"a"} <> {null,"a","a",null}
                    }
                }
            }
            return hashCode;
        }

        private bool CheckValue(PropertyInfo p, T other)
        {
            var left = p.GetValue(this, null);
            var right = p.GetValue(other, null);
            if (left == null || right == null)
            {
                return false;
            }

            if (typeof(T).IsAssignableFrom(left.GetType()))
            {
                //check not self-references...
                return ReferenceEquals(left, right);
            }
            return left.Equals(right);
        }
    }
}
