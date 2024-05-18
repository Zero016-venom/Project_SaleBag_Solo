using Assignment_NET105.Core.Domain.Models;
using System.Linq.Expressions;

namespace Assignment_NET105.RepositoryContracts
{
    public interface IHangRepository
    {
        Task<Hang> AddHang(Hang hang);

        Task<Hang> UpdateHang(Hang hang);

        Task<List<Hang>> GetAllHang();

        Task<Hang?> GetHangByHangID(Guid hangID);

        Task<Hang?> GetHangByTenHang(string tenHang);

        Task<List<Hang>> GetFilteredHang(Expression<Func<Hang, bool>> predicate);
    }
}
