using Api.Domain.Data;
using Api.Domain.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace Api.Domain.Repository.Base
{
    public abstract class Repository<T> : IRepository<T> where T : BaseTable
    {

        private readonly DataContext context;
        private readonly DbSet<T> entity;

        public Repository(DataContext context)
        {
            this.context = context;
            entity = context.Set<T>();
        }

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
            return filter(entity.AsNoTracking()).SingleOrDefault();
        }

        public async Task<T> GetAsync(object id)
        {
            return await entity.FindAsync(id);
        }

        protected async Task<T> GetAsync(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return await filter(entity.AsNoTracking()).SingleOrDefaultAsync();
        }

        public ICollection<T> Select()
        {
            return entity.AsNoTracking().ToList();
        }

        protected ICollection<T> Select(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return filter(entity.AsNoTracking()).ToList();
        }

        public async Task<ICollection<T>> SelectAsync()
        {
            return await entity.AsNoTracking().ToListAsync();
        }

        protected async Task<ICollection<T>> SelectAsync(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return await filter(entity.AsNoTracking()).ToListAsync();
        }

        public T Insert(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            context.ChangeTracker.Clear();
            entity.Add(item);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            return item;
        }

        public ICollection<T> Insert(ICollection<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (!items.Any()) return Enumerable.Empty<T>().ToList();

            context.ChangeTracker.Clear();
            entity.AddRange(items);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            return items.ToList();
        }

        public async Task<T> InsertAsync(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            context.ChangeTracker.Clear();
            await entity.AddAsync(item);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            return item;
        }

        public async Task<ICollection<T>> InsertAsync(ICollection<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (items.Count == 0) return Enumerable.Empty<T>().ToList();

            context.ChangeTracker.Clear();
            await entity.AddRangeAsync(items);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            return items.ToList();
        }

        public T Update(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            context.ChangeTracker.Clear();
            entity.Update(item);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            return item;
        }

        public ICollection<T> Update(ICollection<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (items.Count == 0) return Enumerable.Empty<T>().ToList();

            context.ChangeTracker.Clear();
            entity.UpdateRange(items);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            return items.ToList();
        }

        public async Task<T> UpdateAsync(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            context.ChangeTracker.Clear();
            entity.Update(item);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            return item;
        }

        public async Task<ICollection<T>> UpdateAsync(ICollection<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (items.Count == 0) return Enumerable.Empty<T>().ToList();

            context.ChangeTracker.Clear();
            entity.UpdateRange(items);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            return items.ToList();
        }

        public T Delete(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            context.ChangeTracker.Clear();
            entity.Remove(item);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            return item;
        }

        public ICollection<T> Delete(ICollection<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (items.Count == 0) return Enumerable.Empty<T>().ToList();

            context.ChangeTracker.Clear();
            entity.RemoveRange(items);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            return items.ToList();
        }

        public async Task<T> DeleteAsync(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            context.ChangeTracker.Clear();
            entity.Remove(item);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            return item;
        }

        public async Task<ICollection<T>> DeleteAsync(ICollection<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (items.Count == 0) return Enumerable.Empty<T>().ToList();

            context.ChangeTracker.Clear();
            entity.RemoveRange(items);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            return items.ToList();
        }
    }
}