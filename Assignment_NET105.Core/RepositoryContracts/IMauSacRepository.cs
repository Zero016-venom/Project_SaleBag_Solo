using Assignment_NET105.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.RepositoryContracts
{
    public interface IMauSacRepository
    {
        Task<MauSac> AddMauSac(MauSac mauSac);

        Task<MauSac> UpdateMauSac(MauSac mauSac);

        Task<List<MauSac>> GetAllMauSac();

        Task<MauSac?> GetMauSacByMauSacID(Guid mauSacID);

        Task<MauSac?> GetMauSacByTenMau(string tenMau);

        Task<List<MauSac>> GetFilteredMauSac(Expression<Func<MauSac, bool>> predicate);
    }
}
