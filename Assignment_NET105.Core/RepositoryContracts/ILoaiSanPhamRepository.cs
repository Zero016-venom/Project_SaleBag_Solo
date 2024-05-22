using Assignment_NET105.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.RepositoryContracts
{
    public interface ILoaiSanPhamRepository
    {
        Task<LoaiSP> AddLoaiSanPham(LoaiSP loaiSP);

        Task<LoaiSP> UpdateLoaiSanPham(LoaiSP loaiSP);

        Task<List<LoaiSP>> GetAllLoaiSanPham();

        Task<LoaiSP?> GetLoaiSPByLoaiSPID(Guid ID_LoaiSP);

        Task<LoaiSP?> GetLoaiSPByTenLoaiSP(string tenLoaiSP);

        Task<List<LoaiSP>> GetFilterdLoaiSP(Expression<Func<LoaiSP, bool>> preditor);
    }
}
