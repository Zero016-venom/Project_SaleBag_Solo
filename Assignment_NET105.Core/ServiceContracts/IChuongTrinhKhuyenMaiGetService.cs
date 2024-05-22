using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.ServiceContracts
{
    public interface IChuongTrinhKhuyenMaiGetService
    {
        Task<List<ChuongTrinhKhuyenMaiResponse>> GetAllChuongTrinhKhuyenMai();

        Task<ChuongTrinhKhuyenMaiResponse?> GetChuongTrinhKhuyenMaiByChuongTrinhKhuyenMaiID(Guid? chuongTrinhKhuyenMaiID);

        Task<List<ChuongTrinhKhuyenMaiResponse>> GetFilteredChuongTrinhKhuyenMai(string searchBy, string? searchString);
    }
}
