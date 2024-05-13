using Assignment_NET105.Core.Domain.Models;

namespace Assignment_NET105.RepositoryContracts
{
    public interface ILoaiSPRepository
    {
        Task<Hang> AddHang(Hang hang);

        Task<List<Hang>> GetAllHang();

        Task<Hang?> GetHangByTenHang(string TenHang);
    }
}
