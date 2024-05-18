using Assignment_NET105.Core.Domain.Models;
using System.Linq.Expressions;

namespace Assignment_NET105.RepositoryContracts
{
    public interface ILoaiSPRepository
    {
        Task<LoaiSP> AddLoaiSP(LoaiSP loaiSP);

        Task<LoaiSP> UpdateLoaiSP(LoaiSP loaiSP);

        Task<List<LoaiSP>> GetAllLoaiSP();

        Task<LoaiSP?> GetLoaiSPByLoaiSPID(Guid ID_LoaiSP);

        Task<LoaiSP?> GetLoaiSPByTenLoaiSP(string tenLoaiSP);

        Task<List<LoaiSP>> GetFilteredLoaiSP(Expression<Func<LoaiSP, bool>> predicate);
    }
}
