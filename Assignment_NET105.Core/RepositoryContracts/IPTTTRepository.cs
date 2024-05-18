using Assignment_NET105.Core.Domain.Models;
using System.Linq.Expressions;

namespace Assignment_NET105.RepositoryContracts
{
    public interface IPTTTRepository
    {
        Task<PTTT> AddPTTT(PTTT pttt);

        Task<PTTT> UpdatePTTT(PTTT pttt);

        Task<List<PTTT>> GetAllPTTT();

        Task<PTTT?> GetPTTTByPTTTID(Guid ID_PTTT);

        Task<PTTT?> GetPTTTByTenPTTT(string tenPTTT);

        Task<List<PTTT>> GetFilterdPTTT(Expression<Func<PTTT, bool>> predicate);
    }
}
