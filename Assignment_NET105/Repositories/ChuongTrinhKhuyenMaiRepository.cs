using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Infracstructure.DatabaseContext;
using Assignment_NET105.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105.Repositories
{
    public class ChuongTrinhKhuyenMaiRepository : IChuongTrinhKMRepository
    {
        private readonly ApplicationDbContext _db;

        public ChuongTrinhKhuyenMaiRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ChuongTrinhKhuyenMai> AddChuongTrinhKM(ChuongTrinhKhuyenMai chuongTrinhKhuyenMai)
        {
            _db.ChuongTrinhKhuyenMai.Add(chuongTrinhKhuyenMai);
            await _db.SaveChangesAsync();
            return chuongTrinhKhuyenMai;
        }

        public async Task<List<ChuongTrinhKhuyenMai>> GetAllChuongTrinhKM()
        {
            return await _db.ChuongTrinhKhuyenMai.ToListAsync();
        }

        public async Task<ChuongTrinhKhuyenMai?> GetChuongTrinhKMByTenCTKM(string tenChuongTrinhKM)
        {
            return await _db.ChuongTrinhKhuyenMai.FirstOrDefaultAsync
                (temp => temp.TenChuongTrinhKhuyenMai == tenChuongTrinhKM);
        }

        public async Task<ChuongTrinhKhuyenMai> UpdateChuongTrinhKM(ChuongTrinhKhuyenMai chuongTrinhKhuyenMai)
        {
            ChuongTrinhKhuyenMai? matchingChuongTrinhKM = await _db.ChuongTrinhKhuyenMai.FirstOrDefaultAsync
                (temp => temp.ID_ChuongTrinhKhuyenMai == chuongTrinhKhuyenMai.ID_ChuongTrinhKhuyenMai);

            if (matchingChuongTrinhKM == null)
                return chuongTrinhKhuyenMai;

            matchingChuongTrinhKM.TenChuongTrinhKhuyenMai = chuongTrinhKhuyenMai.TenChuongTrinhKhuyenMai;
            matchingChuongTrinhKM.ID_SanPham = chuongTrinhKhuyenMai.ID_SanPham;
            matchingChuongTrinhKM.NgayBatDau = chuongTrinhKhuyenMai.NgayBatDau;
            matchingChuongTrinhKM.NgayKetThuc = chuongTrinhKhuyenMai.NgayKetThuc;
            matchingChuongTrinhKM.TrangThai = chuongTrinhKhuyenMai.TrangThai;

            int countUpdated = await _db.SaveChangesAsync();
            return matchingChuongTrinhKM;
        }
    }
}
