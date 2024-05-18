using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Core.DTO;
using Assignment_NET105.Core.ServiceContracts;
using Assignment_NET105.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.Services
{
    public class HangAddService : IHangAddService
    {
        private readonly IHangRepository _hangRepository;

        public HangAddService(IHangRepository hangRepository)
        {
            _hangRepository = hangRepository;
        }

        public async Task<HangResponse> AddHang(HangAddRequest? hangAddRequest)
        {
            if(hangAddRequest == null)
                throw new ArgumentNullException(nameof(hangAddRequest));

            if (hangAddRequest.TenHang == null)
                throw new ArgumentNullException(nameof(hangAddRequest.TenHang));

            if(await _hangRepository.GetHangByTenHang(hangAddRequest.TenHang) != null)
            {
                throw new ArgumentException("Tên hãng đã tồn tại !");
            }

            Hang hang = hangAddRequest.ToHang();

            hang.ID_Hang = Guid.NewGuid();
            await _hangRepository.AddHang(hang);

            return hang.ToHangResponse();
        }
    }
}
