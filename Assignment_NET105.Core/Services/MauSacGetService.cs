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
    public class MauSacGetService : IMauSacGetService
    {
        private readonly IMauSacRepository _mauSacRepository;

        public MauSacGetService(IMauSacRepository mauSacRepository)
        {
            _mauSacRepository = mauSacRepository;
        }

        public async Task<List<MauSacResponse>> GetAllMauSac()
        {
            List<MauSac> mauSacs = await _mauSacRepository.GetAllMauSac();
            return mauSacs.Select(temp => temp.ToMauSacResponse()).ToList();
        }

        public async Task<List<MauSacResponse>> GetFilterdMauSac(string searchBy, string? stringSearch)
        {
            List<MauSac> mauSac;

            mauSac = searchBy switch
            {
                (nameof(MauSacResponse.TenMauSac)) => await _mauSacRepository.GetFilteredMauSac(temp => temp.TenMauSac.Contains(stringSearch)),

                (nameof(MauSacResponse.MoTa)) => await _mauSacRepository.GetFilteredMauSac(temp => temp.MoTa.Contains(stringSearch)),

                (nameof(MauSacResponse.TrangThai)) => await _mauSacRepository.GetFilteredMauSac(temp => temp.TrangThai.Contains(stringSearch)),
                _ => await _mauSacRepository.GetAllMauSac()
            };
            return mauSac.Select(temp => temp.ToMauSacResponse()).ToList();
        }

        public async Task<MauSacResponse?> GetMauSacByMauSacID(Guid? mauSacID)
        {
            if (mauSacID == null)
                return null;

            MauSac? mauSac = await _mauSacRepository.GetMauSacByMauSacID(mauSacID.Value);
            if(mauSac == null) return null;
            return mauSac.ToMauSacResponse();
        }
    }
}
