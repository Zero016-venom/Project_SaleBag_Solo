using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Core.DTO;
using Assignment_NET105.Core.ServiceContracts;
using Assignment_NET105.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.Services
{
    public class HangGetService : IHangGetService
    {
        private readonly IHangRepository _hangRepository;

        public HangGetService(IHangRepository hangRepository)
        {
            _hangRepository = hangRepository;
        }

        public async Task<List<HangResponse>> GetAllHang()
        {
            List<Hang> hangs = await _hangRepository.GetAllHang();

            return hangs.Select(temp => temp.ToHangResponse()).ToList();
        }

        public async Task<HangResponse?> GetHangByHangID(Guid? hangID)
        {
            if (hangID == null)
                return null;
            Hang? hang = await _hangRepository.GetHangByHangID(hangID.Value);

            if (hang == null)
                return null;
            return hang.ToHangResponse();
        }

        public async Task<List<HangResponse>> GetFilterdHangs(string searchBy, string? searchString)
        {
            List<Hang> hangs;

            hangs = searchBy switch
            {
                nameof(HangResponse.TenHang) => await _hangRepository.GetFilteredHang(temp => temp.TenHang.Contains(searchString)),

                nameof(HangResponse.MoTa) => await _hangRepository.GetFilteredHang(temp => temp.MoTa.Contains(searchString)),

                nameof(HangResponse.TrangThai) => await _hangRepository.GetFilteredHang(temp => temp.TrangThai.Contains(searchBy)),
                _ => await _hangRepository.GetAllHang()
            };
            return hangs.Select(temp=>temp.ToHangResponse()).ToList();
        }
    }
}
