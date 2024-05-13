using Assignment_NET105.Core.Domain.DTO;

namespace Assignment_NET105.ServiceContracts
{
    public interface IChuongTrinhKMAddService
    {
        Task<ChuongTrinhKMResponse> AddChuongTrinhKhuyenMai(ChuongTrinhKMAddRequest? chuongTrinhKMAddRequest);
    }
}
