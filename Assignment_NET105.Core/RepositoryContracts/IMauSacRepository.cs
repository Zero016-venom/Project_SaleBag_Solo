using Assignment_NET105.Core.Domain.Models;
using System.Linq.Expressions;

namespace Assignment_NET105.RepositoryContracts
{
    public interface IMauSacRepository
    {
        Task<MauSac> AddMau(MauSac mauSac);

        Task<MauSac> UpdateMau(MauSac mauSac);

        Task<List<MauSac>> GetAllMau();

        Task<MauSac?> GetMauByMauSacID(Guid ID_MauSac);

        Task<MauSac?> GetMauByTenMauSac(string tenMauSac);

        Task<List<MauSac>> GetFilterdMauSac(Expression<Func<MauSac, bool>> predicate);
    }
}
