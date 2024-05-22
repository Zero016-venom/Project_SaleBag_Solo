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
    public class PhuongThucThanhToanAddService : IPhuongThucThanhToanAddService
    {
        private readonly IPhuongThucThanhToanRepository _phuongThucThanhToanRepository;

        public PhuongThucThanhToanAddService(IPhuongThucThanhToanRepository phuongThucThanhToanRepository)
        {
            _phuongThucThanhToanRepository = phuongThucThanhToanRepository;
        }

        public async Task<PhuongThucThanhToanResponse> AddPhuongThucThanhToan(PhuongThucThanhToanAddRequest? phuongThucThanhToanAddRequest)
        {
            if (phuongThucThanhToanAddRequest == null)
                throw new ArgumentNullException(nameof(phuongThucThanhToanAddRequest));

            PTTT? pttt = phuongThucThanhToanAddRequest.ToPhuongThucThanhToan();
            pttt.ID_PTTT = Guid.NewGuid();

            await _phuongThucThanhToanRepository.AddPhuongThucThanhToan(pttt);
            return pttt.ToPhuongThucThanhToanResponse();
        }
    }
}
