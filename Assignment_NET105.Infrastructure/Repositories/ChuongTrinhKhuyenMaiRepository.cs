using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Core.RepositoryContracts;
using Assignment_NET105.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Infrastructure.Repositories
{
    public class ChuongTrinhKhuyenMaiRepository : IChuongTrinhKhuyenMaiRepository
    {
        ApplicationDbContext _db;

        public ChuongTrinhKhuyenMaiRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ChuongTrinhKhuyenMai> AddChuongTrinhKhuyenMai(ChuongTrinhKhuyenMai chuongTrinhKhuyenMai)
        {
            _db.ChuongTrinhKhuyenMai.Add(chuongTrinhKhuyenMai);
            await _db.SaveChangesAsync();
            return chuongTrinhKhuyenMai;
        }

        public async Task<List<ChuongTrinhKhuyenMai>> GetAllChuongTrinhKhuyenMai()
        {
            return await _db.ChuongTrinhKhuyenMai.ToListAsync();
        }

        public async Task<ChuongTrinhKhuyenMai?> GetChuongTrinhKhuyenMaiByChuongTrinhKhuyenMaiID(Guid chuongTrinhKhuyenMaiID)
        {
            return await _db.ChuongTrinhKhuyenMai.FirstOrDefaultAsync(temp => temp.ID_ChuongTrinhKhuyenMai == chuongTrinhKhuyenMaiID);
        }

        public async Task<ChuongTrinhKhuyenMai?> GetChuongTrinhKhuyenMaiByTenChuongTrinhKhuyenMai(string tenChuongTrinhKhuyenMai)
        {
            return await _db.ChuongTrinhKhuyenMai.FirstOrDefaultAsync(temp => temp.TenChuongTrinhKhuyenMai == tenChuongTrinhKhuyenMai);
        }

        public async Task<List<ChuongTrinhKhuyenMai>> GetFilterdChuongTrinhKhuyenMai(Expression<Func<ChuongTrinhKhuyenMai, bool>> predicate)
        {
            return await _db.ChuongTrinhKhuyenMai.Where(predicate).ToListAsync();
        }

        public async Task<ChuongTrinhKhuyenMai> UpdateChuongTrinhKhuyenMai(ChuongTrinhKhuyenMai chuongTrinhKhuyenMai)
        {
            ChuongTrinhKhuyenMai? matchingChuongTrinhKhuyenMai = await _db.ChuongTrinhKhuyenMai.FirstOrDefaultAsync(temp => temp.ID_ChuongTrinhKhuyenMai == chuongTrinhKhuyenMai.ID_ChuongTrinhKhuyenMai);
            if (matchingChuongTrinhKhuyenMai == null)
                return chuongTrinhKhuyenMai;

            matchingChuongTrinhKhuyenMai.TenChuongTrinhKhuyenMai = chuongTrinhKhuyenMai.TenChuongTrinhKhuyenMai;
            matchingChuongTrinhKhuyenMai.NgayBatDau = chuongTrinhKhuyenMai.NgayBatDau;
            matchingChuongTrinhKhuyenMai.NgayKetThuc = chuongTrinhKhuyenMai.NgayKetThuc;
            matchingChuongTrinhKhuyenMai.TrangThai = chuongTrinhKhuyenMai.TrangThai;
            matchingChuongTrinhKhuyenMai.ID_SanPham = chuongTrinhKhuyenMai.ID_SanPham;

            await _db.SaveChangesAsync();
            return matchingChuongTrinhKhuyenMai;
        }
    }
}
