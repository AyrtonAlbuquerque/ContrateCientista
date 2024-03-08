using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface ICompanyRepository : IRepository<Company>
    {
    }

    public class CompanyRepository(DataContext context) : Repository<Company>(context), ICompanyRepository
    {
    }
}