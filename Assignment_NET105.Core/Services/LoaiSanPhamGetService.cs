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
    public class LoaiSanPhamGetService : ILoaiSanPhamGetService
    {
        private readonly ILoaiSanPhamRepository _loaiSanPhamRepository;

        public LoaiSanPhamGetService(ILoaiSanPhamRepository loaiSanPhamRepository)
        {
            _loaiSanPhamRepository = loaiSanPhamRepository;
        }

        public async Task<List<LoaiSanPhamResponse>> GetAllLoaiSanPham()
        {
            List<LoaiSP> loaiSP = await _loaiSanPhamRepository.GetAllLoaiSanPham();
            return loaiSP.Select(temp => temp.ToLoaiSanPhamResponse()).ToList();
        }

        public async Task<List<LoaiSanPhamResponse>> GetFilterdLoaiSP(string searchBy, string? searchString)
        {
            List<LoaiSP> loaiSPs;

            loaiSPs = searchBy switch
            {
                nameof(LoaiSanPhamResponse.TenLoaiSP) => await _loaiSanPhamRepository.GetFilterdLoaiSP(temp => temp.TenLoaiSP.Contains(searchString)),

                nameof(LoaiSanPhamResponse.MoTa) => await _loaiSanPhamRepository.GetFilterdLoaiSP(temp => temp.MoTa.Contains(searchString)),

                nameof(LoaiSanPhamResponse.TrangThai) => await _loaiSanPhamRepository.GetFilterdLoaiSP(temp => temp.TrangThai.Contains(searchString)),
                _ => await _loaiSanPhamRepository.GetAllLoaiSanPham()
            };
            return loaiSPs.Select(temp=>temp.ToLoaiSanPhamResponse()).ToList();
        }

        public async Task<LoaiSanPhamResponse?> GetLoaiSPByLoaiSPID(Guid? loaiSPID)
        {
            if (loaiSPID == null)
                return null;

            LoaiSP? loaiSP = await _loaiSanPhamRepository.GetLoaiSPByLoaiSPID(loaiSPID.Value);

            if (loaiSP == null)
                return null;
            return loaiSP.ToLoaiSanPhamResponse();
        }
    }
}
