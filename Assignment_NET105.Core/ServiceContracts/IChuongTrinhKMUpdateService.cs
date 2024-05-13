using Assignment_NET105.Core.Domain.DTO;

namespace Assignment_NET105.ServiceContracts
{
    public interface IChuongTrinhKMUpdateService
    {
        Task<ChuongTrinhKMResponse> UpdateChuongTrinhKM(ChuongTrinhKMUpdateRequest? chuongTrinhKMUpdateRequest);
    }
}
