using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Infrastructure.DatabaseContext;
using Assignment_NET105.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Infrastructure.Repositories
{
    public class LoaiSPRepository : ILoaiSPRepository
    {
        private readonly ApplicationDbContext _db;

        public LoaiSPRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<LoaiSP> AddLoaiSP(LoaiSP loaiSP)
        {
            _db.LoaiSP.Add(loaiSP);
            await _db.SaveChangesAsync();
            return loaiSP;
        }

        public async Task<List<LoaiSP>> GetAllLoaiSP()
        {
            return await _db.LoaiSP.ToListAsync();
        }

        public async Task<List<LoaiSP>> GetFilteredLoaiSP(Expression<Func<LoaiSP, bool>> predicate)
        {
            return await _db.LoaiSP.Where(predicate).ToListAsync();
        }

        public async Task<LoaiSP?> GetLoaiSPByLoaiSPID(Guid ID_LoaiSP)
        {
            return await _db.LoaiSP.FirstOrDefaultAsync(temp => temp.ID_LoaiSP == ID_LoaiSP);
        }

        public async Task<LoaiSP?> GetLoaiSPByTenLoaiSP(string tenLoaiSP)
        {
            return await _db.LoaiSP.FirstOrDefaultAsync(temp => temp.TenLoaiSP == tenLoaiSP);
        }

        public async Task<LoaiSP> UpdateLoaiSP(LoaiSP loaiSP)
        {
            LoaiSP? matchingLoaiSP = await _db.LoaiSP.FirstOrDefaultAsync(temp => temp.ID_LoaiSP == loaiSP.ID_LoaiSP);
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
