using Assignment_NET105.Core.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.ServiceContracts
{
    public interface IMauSacGetService
    {
        Task<List<MauSacResponse>> GetAllMauSac();

        Task<MauSacResponse?> GetMauSacByMauSacID(Guid? mauSacID);

        Task<List<MauSacResponse>> GetFilterdMauSac(string searchBy, string? stringSearch);
    }
}
