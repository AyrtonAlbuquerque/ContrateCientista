using Benchmark.Domain.Data;
using Benchmark.Domain.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace Benchmark.Domain.Repository.Base
{
    public abstract class Repository<T>(Context context) : IRepository<T> where T : BaseTable
    {
        private readonly DbSet<T> entity = context.Set<T>();

        public int Count()
        {
            return entity.Count();
        }

        protected int Count(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return filter(entity.AsQueryable<T>()).Count();
        }

        public async Task<int> CountAsync()
        {
            return await entity.CountAsync();
        }

        protected async Task<int> CountAsync(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return await filter(entity.AsQueryable<T>()).CountAsync();
        }

        protected bool Exists(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return filter(entity.AsQueryable<T>()).Any();
        }

        public async Task<bool> ExistsAsync(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return await filter(entity.AsQueryable<T>()).AnyAsync();
        }

        public T Get(object id)
        {
            return entity.Find(id);
        }

        protected T Get(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return filter(entity.AsQueryable<T>()).SingleOrDefault();
        }

        public async Task<T> GetAsync(object id)
        {
            return await entity.FindAsync(id);
        }

        protected async Task<T> GetAsync(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return await filter(entity.AsQueryable<T>()).SingleOrDefaultAsync();
        }

        public IList<T> Select()
        {
            return entity.AsQueryable<T>().ToList();
        }

        protected IList<T> Select(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return filter(entity.AsQueryable<T>()).ToList();
        }

        public async Task<IList<T>> SelectAsync()
        {
            return await entity.AsQueryable<T>().ToListAsync();
        }

        protected async Task<IList<T>> SelectAsync(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return await filter(entity.AsQueryable<T>()).ToListAsync();
        }

        public T Insert(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            context.ChangeTracker.Clear();
            entity.Attach(item);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            return item;
        }

        public IList<T> Insert(IList<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (!items.Any()) return Enumerable.Empty<T>().ToList();

            context.ChangeTracker.Clear();
            entity.AttachRange(items);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            return items;
        }

        public async Task<T> InsertAsync(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            context.ChangeTracker.Clear();
            entity.Attach(item);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            return item;
        }

        public async Task<IList<T>> InsertAsync(IList<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (items.Count == 0) return Enumerable.Empty<T>().ToList();

            context.ChangeTracker.Clear();
            entity.AttachRange(items);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            return items;
        }

        public T Update(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            entity.Update(item);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            return item;
        }

        public IList<T> Update(IList<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (items.Count == 0) return Enumerable.Empty<T>().ToList();

            entity.UpdateRange(items);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            return items;
        }

        public async Task<T> UpdateAsync(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            entity.Update(item);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            return item;
        }

        public async Task<IList<T>> UpdateAsync(IList<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (items.Count == 0) return Enumerable.Empty<T>().ToList();

            entity.UpdateRange(items);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            return items;
        }

        public T Delete(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            entity.Remove(item);
            context.SaveChanges();

            return item;
        }

        public IList<T> Delete(IList<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (items.Count == 0) return Enumerable.Empty<T>().ToList();

            entity.RemoveRange(items);
            context.SaveChanges();

            return items;
        }

        public async Task<T> DeleteAsync(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            entity.Remove(item);
            await context.SaveChangesAsync();

            return item;
        }

        public async Task<IList<T>> DeleteAsync(IList<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (items.Count == 0) return Enumerable.Empty<T>().ToList();

            entity.RemoveRange(items);
            await context.SaveChangesAsync();

            return items;
        }
    }
}