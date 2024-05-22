using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.ServiceContracts
{
    public interface IPhuongThucThanhToanSortService
    {
        Task<List<PhuongThucThanhToanResponse>> GetSortPhuongThucThanhToan(List<PhuongThucThanhToanResponse> allPhuongThucThanhToan,
            string sortBy, SortOrderOptions sortOrder);
    }
}
