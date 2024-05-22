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
    public class LoaiSanPhamUpdateService : ILoaiSanPhamUpdateRequest
    {
        private readonly ILoaiSanPhamRepository _loaiSanPhamRepository;

        public LoaiSanPhamUpdateService(ILoaiSanPhamRepository loaiSanPhamRepository)
        {
            _loaiSanPhamRepository = loaiSanPhamRepository;
        }

        public async Task<LoaiSanPhamResponse> UpdateLoaiSanPham(LoaiSanPhamUpdateRequest loaiSanPhamUpdateRequest)
        {
            if(loaiSanPhamUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(loaiSanPhamUpdateRequest));
            }

            LoaiSP? matchingLoaiSanPham = await _loaiSanPhamRepository.GetLoaiSPByLoaiSPID(loaiSanPhamUpdateRequest.ID_LoaiSP);
            if(matchingLoaiSanPham == null)
                throw new ArgumentNullException("Không tìm thấy loại sản phẩm");

            matchingLoaiSanPham.TenLoaiSP = loaiSanPhamUpdateRequest.TenLoaiSP;
            matchingLoaiSanPham.MoTa = loaiSanPhamUpdateRequest.MoTa;
            matchingLoaiSanPham.TrangThai = loaiSanPhamUpdateRequest.TrangThai.ToString();

            await _loaiSanPhamRepository.UpdateLoaiSanPham(matchingLoaiSanPham);
            return matchingLoaiSanPham.ToLoaiSanPhamResponse();
        }
    }
}
