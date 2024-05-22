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
    public class MauSacUpdateService : IMauSacUpdateService
    {
        private readonly IMauSacRepository _mauSacRepository;

        public MauSacUpdateService(IMauSacRepository mauSacRepository)
        {
            _mauSacRepository = mauSacRepository;
        }

        public async Task<MauSacResponse> UpdateMauSac(MauSacUpdateRequest? mauSacUpdateRequest)
        {
            if (mauSacUpdateRequest == null)
                throw new ArgumentNullException(nameof(mauSacUpdateRequest));

            MauSac? matchingMauSac = await _mauSacRepository.GetMauSacByMauSacID(mauSacUpdateRequest.ID_MauSac);
            if (matchingMauSac == null)
                throw new ArgumentNullException("Màu sắc không tồn tại");

            matchingMauSac.TenMauSac = mauSacUpdateRequest.TenMauSac;
            matchingMauSac.MoTa = mauSacUpdateRequest.MoTa;
            matchingMauSac.TrangThai = mauSacUpdateRequest.TrangThai.ToString();

            await _mauSacRepository.UpdateMauSac(matchingMauSac);
            return matchingMauSac.ToMauSacResponse();
        }
    }
}
