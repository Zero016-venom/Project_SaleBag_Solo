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
    public class ChuongTrinhKhuyenMaiGetService : IChuongTrinhKhuyenMaiGetService 
    {
        private readonly IChuongTrinhKhuyenMaiRepository _chuongTrinhKhuyenMaiRepository;

        public ChuongTrinhKhuyenMaiGetService(IChuongTrinhKhuyenMaiRepository chuongTrinhKhuyenMaiRepository)
        {
            _chuongTrinhKhuyenMaiRepository = chuongTrinhKhuyenMaiRepository;
        }

        public async Task<List<ChuongTrinhKhuyenMaiResponse>> GetAllChuongTrinhKhuyenMai()
        {
            List<ChuongTrinhKhuyenMai> chuongTrinhKhuyenMais = await _chuongTrinhKhuyenMaiRepository.GetAllChuongTrinhKhuyenMai();
            return chuongTrinhKhuyenMais.Select(temp => temp.ToChuongTrinhKhuyenMaiResponse()).ToList();
        }

        public async Task<ChuongTrinhKhuyenMaiResponse?> GetChuongTrinhKhuyenMaiByChuongTrinhKhuyenMaiID(Guid? chuongTrinhKhuyenMaiID)
        {
            if (chuongTrinhKhuyenMaiID == null)
                return null;

            ChuongTrinhKhuyenMai? chuongTrinhKhuyenMai = await _chuongTrinhKhuyenMaiRepository.GetChuongTrinhKhuyenMaiByChuongTrinhKhuyenMaiID(chuongTrinhKhuyenMaiID.Value);

            if (chuongTrinhKhuyenMai == null)
                return null;

            return chuongTrinhKhuyenMai.ToChuongTrinhKhuyenMaiResponse();
        }

        public async Task<List<ChuongTrinhKhuyenMaiResponse>> GetFilteredChuongTrinhKhuyenMai(string searchBy, string? searchString)
        {
            List<ChuongTrinhKhuyenMai> chuongTrinhKhuyenMais;

            chuongTrinhKhuyenMais = searchBy switch
            {
                nameof(ChuongTrinhKhuyenMaiResponse.TenChuongTrinhKhuyenMai) =>
                await _chuongTrinhKhuyenMaiRepository.GetFilterdChuongTrinhKhuyenMai(temp => temp.TenChuongTrinhKhuyenMai.Contains(searchString)),

                nameof(ChuongTrinhKhuyenMaiResponse.TrangThai) =>
                await _chuongTrinhKhuyenMaiRepository.GetFilterdChuongTrinhKhuyenMai(temp => temp.TrangThai.Contains(searchString)),

                nameof(ChuongTrinhKhuyenMaiResponse.NgayBatDau) =>
                await _chuongTrinhKhuyenMaiRepository.GetFilterdChuongTrinhKhuyenMai(temp => temp.NgayBatDau.ToString().Contains(searchString)),

                nameof(ChuongTrinhKhuyenMaiResponse.NgayKetThuc) =>
                await _chuongTrinhKhuyenMaiRepository.GetFilterdChuongTrinhKhuyenMai(temp => temp.NgayKetThuc.ToString().Contains(searchString)),

                nameof(ChuongTrinhKhuyenMaiResponse.ID_SanPham) =>
                await _chuongTrinhKhuyenMaiRepository.GetFilterdChuongTrinhKhuyenMai(temp => temp.ID_SanPham.ToString().Contains(searchString)),
                _ => await _chuongTrinhKhuyenMaiRepository.GetAllChuongTrinhKhuyenMai()
            };
            return chuongTrinhKhuyenMais.Select(temp => temp.ToChuongTrinhKhuyenMaiResponse()).ToList();
        }
    }
}
