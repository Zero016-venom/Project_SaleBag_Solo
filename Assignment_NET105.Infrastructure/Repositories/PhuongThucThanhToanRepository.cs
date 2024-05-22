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
    public class PhuongThucThanhToanRepository : IPhuongThucThanhToanRepository
    {
        private readonly ApplicationDbContext _db;

        public PhuongThucThanhToanRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PTTT> AddPhuongThucThanhToan(PTTT phuongThucThanhToan)
        {
            _db.PTTT.Add(phuongThucThanhToan);
            await _db.SaveChangesAsync();
            return phuongThucThanhToan;
        }

        public async Task<List<PTTT>> GetAllPhuongThucThanhToan()
        {
            return await _db.PTTT.ToListAsync();
        }

        public async Task<List<PTTT>> GetFilteredPhuongThucThanhToan(Expression<Func<PTTT, bool>> predicate)
        {
            return await _db.PTTT.Where(predicate).ToListAsync();
        }

        public async Task<PTTT?> GetPhuongThucThanhToanByPTTTID(Guid phuongThucThanhToanID)
        {
            return await _db.PTTT.FirstOrDefaultAsync(temp => temp.ID_PTTT == phuongThucThanhToanID);
        }

        public async Task<PTTT?> GetPhuongThucThanhToanByTenPTTT(string tenPhuongThucThanhToan)
        {
            return await _db.PTTT.FirstOrDefaultAsync(temp => temp.TenPTTT == tenPhuongThucThanhToan);
        }

        public async Task<PTTT> UpdatePhuongThucThanhToan(PTTT phuongThucThanhToan)
        {
            PTTT? matchingPhuongThucThanhToan = await _db.PTTT.FirstOrDefaultAsync(temp => temp.ID_PTTT == phuongThucThanhToan.ID_PTTT);
            if (matchingPhuongThucThanhToan == null)
                return phuongThucThanhToan;

            matchingPhuongThucThanhToan.TenPTTT = phuongThucThanhToan.TenPTTT;
            matchingPhuongThucThanhToan.MoTa = phuongThucThanhToan.MoTa;
            matchingPhuongThucThanhToan.TrangThai = phuongThucThanhToan.TrangThai;

            await _db.SaveChangesAsync();
            return matchingPhuongThucThanhToan;
        }
    }
}
