using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.ServiceContracts
{
    public interface IMauSacSortService
    {
        Task<List<MauSacResponse>> GetSortMauSac(List<MauSacResponse> allMauSac, string sortBy, SortOrderOptions sortOrder);
    }
}
