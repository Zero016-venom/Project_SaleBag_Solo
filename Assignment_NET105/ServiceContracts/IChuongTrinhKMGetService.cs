using Assignment_NET105.Core.Domain.DTO;

namespace Assignment_NET105.ServiceContracts
{
    public interface IChuongTrinhKMGetService
    {
        Task<List<ChuongTrinhKMResponse>> GetAllChuongTrinhKM();

        Task<ChuongTrinhKMResponse?> GetChuongTrinhKMByChuongTrinhKMID(Guid? chuongTrinhKMID);
    }
}
