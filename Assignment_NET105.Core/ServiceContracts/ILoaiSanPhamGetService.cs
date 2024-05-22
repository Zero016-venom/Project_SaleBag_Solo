using Assignment_NET105.Core.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.ServiceContracts
{
    public interface ILoaiSanPhamGetService
    {
        Task<List<LoaiSanPhamResponse>> GetAllLoaiSanPham();

        Task<LoaiSanPhamResponse?> GetLoaiSPByLoaiSPID(Guid? loaiSPID);

        Task<List<LoaiSanPhamResponse>> GetFilterdLoaiSP(string searchBy, string? searchString);
    }
}
