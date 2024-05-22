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
    public class LoaiSanPhamAddService : ILoaiSanPhamAddRequest
    {
        private readonly ILoaiSanPhamRepository _loaiSanPhamRepository;

        public LoaiSanPhamAddService(ILoaiSanPhamRepository loaiSanPhamRepository)
        {
            _loaiSanPhamRepository = loaiSanPhamRepository;
        }

        public async Task<LoaiSanPhamResponse> AddLoaiSanPham(LoaiSanPhamAddRequest? sanPhamAddRequest)
        {
            if(sanPhamAddRequest == null)
            {
                throw new ArgumentNullException(nameof(sanPhamAddRequest));
            }
            LoaiSP loaiSanPham = sanPhamAddRequest.ToLoaiSP();
            loaiSanPham.ID_LoaiSP = Guid.NewGuid();
            await _loaiSanPhamRepository.AddLoaiSanPham(loaiSanPham);

            return loaiSanPham.ToLoaiSanPhamResponse();
        }
    }
}
