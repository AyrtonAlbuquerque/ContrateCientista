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
        IList<T> Insert(IList<T> items);
        Task<IList<T>> InsertAsync(IList<T> items);
        T Update(T item);
        Task<T> UpdateAsync(T item);
        IList<T> Update(IList<T> items);
        Task<IList<T>> UpdateAsync(IList<T> items);
        T Delete(T item);
        Task<T> DeleteAsync(T item);
        IList<T> Delete(IList<T> items);
        Task<IList<T>> DeleteAsync(IList<T> items);
    }
}