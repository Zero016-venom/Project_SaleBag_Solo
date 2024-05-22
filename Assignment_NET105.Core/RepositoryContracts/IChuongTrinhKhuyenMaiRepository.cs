using Assignment_NET105.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.RepositoryContracts
{
    public interface IChuongTrinhKhuyenMaiRepository
    {
        Task<ChuongTrinhKhuyenMai> AddChuongTrinhKhuyenMai(ChuongTrinhKhuyenMai chuongTrinhKhuyenMai);

        Task<ChuongTrinhKhuyenMai> UpdateChuongTrinhKhuyenMai(ChuongTrinhKhuyenMai chuongTrinhKhuyenMai);

        Task<List<ChuongTrinhKhuyenMai>> GetAllChuongTrinhKhuyenMai();

        Task<ChuongTrinhKhuyenMai?> GetChuongTrinhKhuyenMaiByChuongTrinhKhuyenMaiID(Guid chuongTrinhKhuyenMaiID);

        Task<ChuongTrinhKhuyenMai?> GetChuongTrinhKhuyenMaiByTenChuongTrinhKhuyenMai(string tenChuongTrinhKhuyenMai);

        Task<List<ChuongTrinhKhuyenMai>> GetFilterdChuongTrinhKhuyenMai(Expression<Func<ChuongTrinhKhuyenMai, bool>> predicate);
    }
}
