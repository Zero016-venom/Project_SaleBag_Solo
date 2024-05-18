using Assignment_NET105.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.ServiceContracts
{
    public interface IHangGetService
    {
        Task<List<HangResponse>> GetAllHang();

        Task<HangResponse?> GetHangByHangID(Guid? hangID);

        Task<List<HangResponse>> GetFilterdHangs(string searchBy, string? searchString);
    }
}
