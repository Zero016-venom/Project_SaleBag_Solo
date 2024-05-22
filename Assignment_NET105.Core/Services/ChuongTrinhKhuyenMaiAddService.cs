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
    public class ChuongTrinhKhuyenMaiAddService : IChuongTrinhKhuyenMaiAddService
    {
        private readonly IChuongTrinhKhuyenMaiRepository _chuongTrinhKhuyenMaiRepository;

        public ChuongTrinhKhuyenMaiAddService(IChuongTrinhKhuyenMaiRepository chuongTrinhKhuyenMaiRepository)
        {
            _chuongTrinhKhuyenMaiRepository = chuongTrinhKhuyenMaiRepository;
        }
        public async Task<ChuongTrinhKhuyenMaiResponse> AddChuongTrinhKhuyenMai(ChuongTrinhKhuyenMaiAddRequest? chuongTrinhKhuyenMaiAddRequest)
        {
            if (chuongTrinhKhuyenMaiAddRequest == null)
                throw new ArgumentNullException(nameof(chuongTrinhKhuyenMaiAddRequest));

            if (chuongTrinhKhuyenMaiAddRequest.TenChuongTrinhKhuyenMai == null)
                throw new ArgumentNullException(nameof(chuongTrinhKhuyenMaiAddRequest.TenChuongTrinhKhuyenMai));

            if (await _chuongTrinhKhuyenMaiRepository.GetChuongTrinhKhuyenMaiByTenChuongTrinhKhuyenMai(chuongTrinhKhuyenMaiAddRequest.TenChuongTrinhKhuyenMai) != null)
            {
                throw new ArgumentException("Tên chương trình khuyến mãi đã tồn tại !");
            }

            ChuongTrinhKhuyenMai chuongTrinhKhuyenMai = chuongTrinhKhuyenMaiAddRequest.ToChuongTrinhKhuyenMai();
            chuongTrinhKhuyenMai.ID_ChuongTrinhKhuyenMai = Guid.NewGuid();

            await _chuongTrinhKhuyenMaiRepository.AddChuongTrinhKhuyenMai(chuongTrinhKhuyenMai);
            return chuongTrinhKhuyenMai.ToChuongTrinhKhuyenMaiResponse();
        }
    }
}
