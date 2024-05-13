using Assignment_NET105.Core.Domain.Models;

namespace Assignment_NET105.RepositoryContracts
{
    public interface IHoaDonRepository
    {
        Task<HoaDon> AddHoaDon(HoaDon hoaDon);

        Task<HoaDon> UpdateHoaDon(HoaDon hoaDon);

        Task<List<HoaDon>> GetAllHoaDon();

        Task<HoaDon?> GetHoaDonByHoaDonID(Guid hoaDonID);

    }
}
