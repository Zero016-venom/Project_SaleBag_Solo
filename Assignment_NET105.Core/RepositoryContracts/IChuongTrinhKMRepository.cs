using Assignment_NET105.Core.Domain.Models;

namespace Assignment_NET105.RepositoryContracts
{
    public interface IChuongTrinhKMRepository
    {
        Task<ChuongTrinhKhuyenMai> AddChuongTrinhKM(ChuongTrinhKhuyenMai chuongTrinhKhuyenMai);

        Task<ChuongTrinhKhuyenMai> UpdateChuongTrinhKM(ChuongTrinhKhuyenMai chuongTrinhKhuyenMai);

        Task<List<ChuongTrinhKhuyenMai>> GetAllChuongTrinhKM();

        Task<ChuongTrinhKhuyenMai?> GetChuongTrinhKMByTenCTKM(string tenChuongTrinhKM); 
    }
}
