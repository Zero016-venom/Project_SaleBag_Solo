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
    public class LoaiSanPhamRepository : ILoaiSanPhamRepository
    {
        ApplicationDbContext _db;

        public LoaiSanPhamRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<LoaiSP> AddLoaiSanPham(LoaiSP loaiSP)
        {
            _db.LoaiSP.Add(loaiSP);
            await _db.SaveChangesAsync();
            return loaiSP;
        }

        public async Task<List<LoaiSP>> GetAllLoaiSanPham()
        {
            return await _db.LoaiSP.ToListAsync();
        }

        public async Task<List<LoaiSP>> GetFilterdLoaiSP(Expression<Func<LoaiSP, bool>> preditor)
        {
            return await _db.LoaiSP.Where(preditor).ToListAsync();
        }

        public async Task<LoaiSP?> GetLoaiSPByLoaiSPID(Guid ID_LoaiSP)
        {
            return await _db.LoaiSP.FirstOrDefaultAsync(temp => temp.ID_LoaiSP == ID_LoaiSP);
        }

        public async Task<LoaiSP?> GetLoaiSPByTenLoaiSP(string tenLoaiSP)
        {
            return await _db.LoaiSP.FirstOrDefaultAsync(temp => temp.TenLoaiSP == tenLoaiSP);
        }

        public async Task<LoaiSP> UpdateLoaiSanPham(LoaiSP loaiSP)
        {
            LoaiSP? matchingLoaiSP = _db.LoaiSP.FirstOrDefault(temp => temp.ID_LoaiSP == loaiSP.ID_LoaiSP);
            if (matchingLoaiSP == null)
                return loaiSP;

            matchingLoaiSP.TenLoaiSP = loaiSP.TenLoaiSP;
            matchingLoaiSP.MoTa = loaiSP.MoTa;
            matchingLoaiSP.TrangThai = loaiSP.TrangThai;

            await _db.SaveChangesAsync();
            return matchingLoaiSP;
        }
    }
}
