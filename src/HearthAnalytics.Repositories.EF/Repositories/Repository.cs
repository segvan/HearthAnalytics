using HearthAnalytics.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HearthAnalytics.Repositories.EF.Repositories
{
    public abstract class Repository<T, K> : IRepository<T, K> where T : BaseEntity<K>
    {
        public virtual HearthAnalyticsDBContext DBContext { get; }

        public Repository(HearthAnalyticsDBContext dbContext)
        {
            this.DBContext = dbContext;
        }

        public virtual void Add(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }

            this.DBContext.Set<T>().Add(entity);
        }

        public virtual IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = this.DBContext.Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }

            return items;
        }

        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = this.DBContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }

            return items.Where(predicate);
        }

        public virtual T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            T result = FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));

            return result;
        }

        public virtual void Remove(K id)
        {
            T item = FindById(id);
            if (item != null)
            {
                Remove(item);
            }else
            {
                throw new ArgumentException();
            }
        }

        public virtual void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            this.DBContext.Remove(entity);
        }

        public void Dispose()
        {
            if(this.DBContext!= null)
            {
                this.DBContext.Dispose();
            }
        }
    }
}
