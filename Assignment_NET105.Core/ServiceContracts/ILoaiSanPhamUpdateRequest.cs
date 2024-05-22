using Assignment_NET105.Core.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.ServiceContracts
{
    public interface ILoaiSanPhamUpdateRequest
    {
        Task<LoaiSanPhamResponse> UpdateLoaiSanPham(LoaiSanPhamUpdateRequest loaiSanPhamUpdateRequest);
    }
}
