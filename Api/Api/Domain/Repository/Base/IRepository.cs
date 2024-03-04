using Api.Domain.Model.Base;

namespace Api.Domain.Repository.Base
{
    public interface IRepository<T> where T : BaseTable
    {
        int Count();
        Task<int> CountAsync();
        T Get(object id);
        Task<T> GetAsync(object id);
        IList<T> Select();
        Task<IList<T>> SelectAsync();
        T Insert(T item);
        Task<T> InsertAsync(T item);
        IList<T> Insert(ICollection<T> items);
        Task<IList<T>> InsertAsync(ICollection<T> items);
        T Update(T item);
        Task<T> UpdateAsync(T item);
        IList<T> Update(ICollection<T> items);
        Task<IList<T>> UpdateAsync(ICollection<T> items);
        T Delete(T item);
        Task<T> DeleteAsync(T item);
        IList<T> Delete(ICollection<T> items);
        Task<IList<T>> DeleteAsync(ICollection<T> items);
    }
}