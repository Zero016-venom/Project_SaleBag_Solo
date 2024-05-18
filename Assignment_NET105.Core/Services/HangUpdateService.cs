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
    public class HangUpdateService : IHangUpdateService
    {
        private readonly IHangRepository _hangRepository;

        public HangUpdateService(IHangRepository hangRepository)
        {
            _hangRepository = hangRepository;
        }

        public async Task<HangResponse> UpdateHang(HangUpdateRequest? hangUpdateRequest)
        {
            if(hangUpdateRequest == null)
                throw new ArgumentNullException(nameof(hangUpdateRequest));

            Hang? matchingHang = await _hangRepository.GetHangByHangID(hangUpdateRequest.ID_Hang);
            if (matchingHang == null)
                throw new ArgumentException("ID hãng không tồn tại !");

            matchingHang.TenHang = hangUpdateRequest.TenHang;
            matchingHang.MoTa = hangUpdateRequest.MoTa;
            matchingHang.TrangThai = hangUpdateRequest.TrangThai.ToString();

            await _hangRepository.UpdateHang(matchingHang);
            return matchingHang.ToHangResponse();
        }
    }
}
