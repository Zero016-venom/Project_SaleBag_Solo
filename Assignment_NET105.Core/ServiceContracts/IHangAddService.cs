using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.ServiceContracts
{
    public interface IHangAddService
    {
        Task<HangResponse> AddHang(HangAddRequest? hangAddRequest);
    }
}
