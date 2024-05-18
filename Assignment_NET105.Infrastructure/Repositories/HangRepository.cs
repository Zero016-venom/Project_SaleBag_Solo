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
    public class HangRepository : IHangRepository
    {
        ApplicationDbContext _db;

        public HangRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Hang> AddHang(Hang hang)
        {
            _db.Hang.Add(hang);
            await _db.SaveChangesAsync();
            return hang;
        }

        public async Task<List<Hang>> GetAllHang()
        {
            return await _db.Hang.ToListAsync();
        }

        public async Task<List<Hang>> GetFilteredHang(Expression<Func<Hang, bool>> predicate)
        {
            return await _db.Hang.Where(predicate).ToListAsync();
        }

        public async Task<Hang?> GetHangByHangID(Guid hangID)
        {
            return await _db.Hang.FirstOrDefaultAsync(temp => temp.ID_Hang == hangID);
        }

        public async Task<Hang?> GetHangByTenHang(string tenHang)
        {
            return await _db.Hang.FirstOrDefaultAsync(temp => temp.TenHang == tenHang);
        }

        public async Task<Hang> UpdateHang(Hang hang)
        {
            Hang? matchingHang = await _db.Hang.FirstOrDefaultAsync(temp => temp.ID_Hang == hang.ID_Hang);
            if (matchingHang == null)
                return hang;

            matchingHang.TenHang = hang.TenHang;
            matchingHang.MoTa = hang.MoTa;
            matchingHang.TrangThai = hang.TrangThai;

            await _db.SaveChangesAsync();
            return matchingHang;
        }
    }
}
