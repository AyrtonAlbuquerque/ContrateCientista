using Api.Domain.Model.Base;

namespace Api.Domain.Repository.Base
{
    public interface IRepository<T> where T : BaseTable
    {
        int Count();
        Task<int> CountAsync();
        T Get(object id);
        Task<T> GetAsync(object id);
        ICollection<T> Select();
        Task<ICollection<T>> SelectAsync();
        T Insert(T item);
        Task<T> InsertAsync(T item);
        ICollection<T> Insert(ICollection<T> items);
        Task<ICollection<T>> InsertAsync(ICollection<T> items);
        T Update(T item);
        Task<T> UpdateAsync(T item);
        ICollection<T> Update(ICollection<T> items);
        Task<ICollection<T>> UpdateAsync(ICollection<T> items);
        T Delete(T item);
        Task<T> DeleteAsync(T item);
        ICollection<T> Delete(ICollection<T> items);
        Task<ICollection<T>> DeleteAsync(ICollection<T> items);
    }
}