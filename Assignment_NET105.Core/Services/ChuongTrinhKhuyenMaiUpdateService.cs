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
    public class ChuongTrinhKhuyenMaiUpdateService : IChuongTrinhKhuyenMaiUpdateService
    {
        private readonly IChuongTrinhKhuyenMaiRepository _chuongTrinhKhuyenMaiRepository;

        public ChuongTrinhKhuyenMaiUpdateService(IChuongTrinhKhuyenMaiRepository chuongTrinhKhuyenMaiRepository)
        {
            _chuongTrinhKhuyenMaiRepository = chuongTrinhKhuyenMaiRepository;
        }

        public async Task<ChuongTrinhKhuyenMaiResponse> UpdateChuongTrinhKhuyenMai(ChuongTrinhKhuyenMaiUpdateRequest? chuongTrinhKhuyenMaiUpdateRequest)
        {
            if(chuongTrinhKhuyenMaiUpdateRequest == null)
                throw new ArgumentNullException(nameof(chuongTrinhKhuyenMaiUpdateRequest));

            ChuongTrinhKhuyenMai? matchingChuongTrinhKhuyenMai = await _chuongTrinhKhuyenMaiRepository.GetChuongTrinhKhuyenMaiByChuongTrinhKhuyenMaiID(chuongTrinhKhuyenMaiUpdateRequest.ID_ChuongTrinhKhuyenMai);
            if (matchingChuongTrinhKhuyenMai == null)
                throw new ArgumentException("ID chương trình khuyến mãi không tồn tại");

            matchingChuongTrinhKhuyenMai.TenChuongTrinhKhuyenMai = chuongTrinhKhuyenMaiUpdateRequest.TenChuongTrinhKhuyenMai;
            matchingChuongTrinhKhuyenMai.NgayBatDau = chuongTrinhKhuyenMaiUpdateRequest.NgayBatDau;
            matchingChuongTrinhKhuyenMai.NgayKetThuc = chuongTrinhKhuyenMaiUpdateRequest.NgayKetThuc;
            matchingChuongTrinhKhuyenMai.TrangThai = chuongTrinhKhuyenMaiUpdateRequest.TrangThai.ToString();
            matchingChuongTrinhKhuyenMai.ID_SanPham = chuongTrinhKhuyenMaiUpdateRequest.ID_SanPham;

            await _chuongTrinhKhuyenMaiRepository.UpdateChuongTrinhKhuyenMai(matchingChuongTrinhKhuyenMai);
            return matchingChuongTrinhKhuyenMai.ToChuongTrinhKhuyenMaiResponse();
        }
    }
}
