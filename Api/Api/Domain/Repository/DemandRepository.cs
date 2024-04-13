using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IDemandRepository : IRepository<Demand>
    {
        Task<IList<Demand>> SelectAsync(Company company);
    }

    public class DemandRepository(DataContext context) : Repository<Demand>(context), IDemandRepository
    {
        public async Task<IList<Demand>> SelectAsync(Company company)
        {
            ArgumentNullException.ThrowIfNull(company);

            return await SelectAsync(q => q
                .Where(d => d.Company == company));
        }
    }
}