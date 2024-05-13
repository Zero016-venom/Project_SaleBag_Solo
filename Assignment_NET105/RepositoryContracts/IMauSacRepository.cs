using Assignment_NET105.Core.Domain.Models;

namespace Assignment_NET105.RepositoryContracts
{
    public interface IMauSacRepository
    {
        Task<MauSac> AddMauSac(MauSac mauSac);

        Task<List<MauSac>> GetAllMauSac();

        Task<MauSac?> GetMauSacByTenMauSac(string TenMauSac);
    }
}
