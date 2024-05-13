using Assignment_NET105.Core.Domain.Models;

namespace Assignment_NET105.RepositoryContracts
{
    public interface IPTTTRepository
    {
        Task<PTTT> AddPTTT(PTTT pttt);

        Task<List<PTTT>> GetAllPTTTs();

        Task<PTTT> GetPTTTByTenPTTT(string tenPTTT);
    }
}
