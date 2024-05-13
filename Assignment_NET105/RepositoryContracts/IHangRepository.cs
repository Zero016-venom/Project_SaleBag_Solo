using Assignment_NET105.Core.Domain.Models;

namespace Assignment_NET105.RepositoryContracts
{
    public interface IHangRepository
    {
        Task<Hang> AddHang();
        Task<List<Hang>> GetAllHang();

        Task<Hang?> GetHangByTenHang(string tenHang);
    }
}
