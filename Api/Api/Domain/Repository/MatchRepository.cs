using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IMatchRepository : IRepository<Match>
    {
        Task<IList<Match>> SelectAsync(User user, int? demand, int? laboratory);
    }

    public class MatchRepository(DataContext context) : Repository<Match>(context), IMatchRepository
    {
        public async Task<IList<Match>> SelectAsync(User user, int? demand, int? laboratory)
        {
            ArgumentNullException.ThrowIfNull(nameof(user));

            if (user.Company != null)
            {
                if (demand.HasValue && laboratory.HasValue)
                {
                    return await SelectAsync(q => q
                        .Where(x => x.Demand.Id == demand && x.Laboratory.Id == laboratory && x.Demand.Company == user.Company));
                }
                else if (demand.HasValue)
                {
                    return await SelectAsync(q => q
                        .Where(x => x.Demand.Id == demand && x.Demand.Company == user.Company));
                }
                else if (laboratory.HasValue)
                {
                    return await SelectAsync(q => q
                        .Where(x => x.Laboratory.Id == laboratory && x.Demand.Company == user.Company));
                }
                else
                {
                    return await SelectAsync(q => q
                        .Where(x => x.Demand.Company == user.Company));
                }
            }
            else
            {
                if (demand.HasValue && laboratory.HasValue)
                {
                    return await SelectAsync(q => q
                        .Where(x => x.Demand.Id == demand && x.Laboratory.Id == laboratory && x.Liked == true && x.Laboratory == user.Laboratory));
                }
                else if (demand.HasValue)
                {
                    return await SelectAsync(q => q
                        .Where(x => x.Demand.Id == demand && x.Liked == true && x.Laboratory == user.Laboratory));
                }
                else if (laboratory.HasValue)
                {
                    return await SelectAsync(q => q
                        .Where(x => x.Laboratory.Id == laboratory && x.Liked == true && x.Laboratory == user.Laboratory));
                }
                else
                {
                    return await SelectAsync(q => q
                        .Where(x => x.Liked == true && x.Laboratory == user.Laboratory));
                }
            }
        }
    }
}