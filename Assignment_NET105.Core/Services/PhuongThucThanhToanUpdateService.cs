using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Core.RepositoryContracts;
using Assignment_NET105.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.Services
{
    public class PhuongThucThanhToanUpdateService : IPhuongThucThanhToanUpdateService
    {
        private readonly IPhuongThucThanhToanRepository _phuongThucThanhToanRepository;

        public PhuongThucThanhToanUpdateService(IPhuongThucThanhToanRepository phuongThucThanhToanRepository)
        {
            _phuongThucThanhToanRepository = phuongThucThanhToanRepository;
        }

        public async Task<PhuongThucThanhToanResponse> UpdatePhuongThucThanhToan(PhuongThucThanhToanUpdateRequest phuongThucThanhToanUpdateRequest)
        {
            if (phuongThucThanhToanUpdateRequest == null)
                throw new ArgumentNullException(nameof(phuongThucThanhToanUpdateRequest));
            PTTT? matchingPhuongThucThanhToan = await _phuongThucThanhToanRepository.GetPhuongThucThanhToanByPTTTID(phuongThucThanhToanUpdateRequest.ID_PhuongThucThanhToan);

            if (matchingPhuongThucThanhToan == null)
                throw new ArgumentNullException("Không tìm thấy phương thức thanh toán");

            matchingPhuongThucThanhToan.TenPTTT = phuongThucThanhToanUpdateRequest.TenPTTT;
            matchingPhuongThucThanhToan.MoTa = phuongThucThanhToanUpdateRequest.MoTa;
            matchingPhuongThucThanhToan.TrangThai = phuongThucThanhToanUpdateRequest.TrangThai.ToString();

            await _phuongThucThanhToanRepository.UpdatePhuongThucThanhToan(matchingPhuongThucThanhToan);
            return matchingPhuongThucThanhToan.ToPhuongThucThanhToanResponse();
        }
    }
}
