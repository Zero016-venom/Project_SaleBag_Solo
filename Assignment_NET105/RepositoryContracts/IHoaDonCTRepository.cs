using Assignment_NET105.Core.Domain.Models;

namespace Assignment_NET105.RepositoryContracts
{
    public interface IHoaDonCTRepository
    {
        Task<HoaDonCT> AddHoaDonCT(HoaDonCT hoaDonCT);

        Task<HoaDonCT> UpdateHoaDonCT(HoaDonCT hoaDonCT);

        Task<bool> DeleteHoaDonCT(Guid id_hoaDonCT);
    }
}
