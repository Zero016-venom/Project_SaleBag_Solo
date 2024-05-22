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
    public class MauSacRepository : IMauSacRepository
    {
        private readonly ApplicationDbContext _db;

        public MauSacRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<MauSac> AddMauSac(MauSac mauSac)
        {
            _db.MauSac.Add(mauSac);
            await _db.SaveChangesAsync();
            return mauSac;
        }

        public async Task<List<MauSac>> GetAllMauSac()
        {
            return await _db.MauSac.ToListAsync();
        }

        public async Task<List<MauSac>> GetFilteredMauSac(Expression<Func<MauSac, bool>> predicate)
        {
            return await _db.MauSac.Where(predicate).ToListAsync();
        }

        public async Task<MauSac?> GetMauSacByMauSacID(Guid mauSacID)
        {
            return await _db.MauSac.FirstOrDefaultAsync(temp => temp.ID_MauSac == mauSacID);
        }

        public async Task<MauSac?> GetMauSacByTenMau(string tenMau)
        {
            return await _db.MauSac.FirstOrDefaultAsync(temp => temp.TenMauSac == tenMau);
        }

        public async Task<MauSac> UpdateMauSac(MauSac mauSac)
        {
            MauSac? matchingMauSac = await _db.MauSac.FirstOrDefaultAsync(temp => temp.ID_MauSac == mauSac.ID_MauSac);
            if (matchingMauSac == null)
                return mauSac;

            matchingMauSac.TenMauSac = mauSac.TenMauSac;
            matchingMauSac.MoTa = matchingMauSac.MoTa;
            matchingMauSac.TrangThai = mauSac.TrangThai;

            return matchingMauSac;
        }
    }
}
