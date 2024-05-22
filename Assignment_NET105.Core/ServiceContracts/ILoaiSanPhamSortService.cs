using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.ServiceContracts
{
    public interface ILoaiSanPhamSortService
    {
        Task<List<LoaiSanPhamResponse>> GetSortLoaiSanPham(List<LoaiSanPhamResponse> allLoaiSanPham, string sortBy, SortOrderOptions sortOrder);
    }
}
