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
    public class PhuongThucThanhToanGetService : IPhuongThucThanhToanGetService
    {
        private readonly IPhuongThucThanhToanRepository _phuongThucThanhToanRepository;

        public PhuongThucThanhToanGetService(IPhuongThucThanhToanRepository phuongThucThanhToanRepository)
        {
            _phuongThucThanhToanRepository = phuongThucThanhToanRepository;
        }

        public async Task<List<PhuongThucThanhToanResponse>> GetAllPhuongThucThanhToan()
        {
            List<PTTT> phuongThucThanhToan = await _phuongThucThanhToanRepository.GetAllPhuongThucThanhToan();
            return phuongThucThanhToan.Select(temp => temp.ToPhuongThucThanhToanResponse()).ToList();
        }

        public async Task<List<PhuongThucThanhToanResponse>> GetFilterdPhuongThucThanhToan(string searchBy, string? searchString)
        {
            List<PTTT> phuongThucThanhToan;

            phuongThucThanhToan = searchBy switch
            {
                nameof(PhuongThucThanhToanResponse.TenPTTT)
                => await _phuongThucThanhToanRepository.GetFilteredPhuongThucThanhToan(temp => temp.TenPTTT.Contains(searchString)),

                nameof(PhuongThucThanhToanResponse.MoTa)
                => await _phuongThucThanhToanRepository.GetFilteredPhuongThucThanhToan(temp => temp.MoTa.Contains(searchString)),

                nameof(PhuongThucThanhToanResponse.TrangThai)
                => await _phuongThucThanhToanRepository.GetFilteredPhuongThucThanhToan(temp => temp.TrangThai.Contains(searchString)),
                _ => await _phuongThucThanhToanRepository.GetAllPhuongThucThanhToan()
            };
            return phuongThucThanhToan.Select(temp => temp.ToPhuongThucThanhToanResponse()).ToList();
        }

        public async Task<PhuongThucThanhToanResponse?> GetPhuongThucThanhToanByPTTTID(Guid? phuongThucThanhToanID)
        {
            if (phuongThucThanhToanID == null)
                return null;
            PTTT? phuongThucThanhToan = await _phuongThucThanhToanRepository.GetPhuongThucThanhToanByPTTTID(phuongThucThanhToanID.Value);
            if (phuongThucThanhToan == null)
                return null;
            return phuongThucThanhToan.ToPhuongThucThanhToanResponse();
        }
    }
}
