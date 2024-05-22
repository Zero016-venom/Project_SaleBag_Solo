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
    public class MauSacAddService : IMauSacAddService
    {
        private readonly IMauSacRepository _mauSacRepository;

        public MauSacAddService(IMauSacRepository mauSacRepository)
        {
            _mauSacRepository = mauSacRepository;
        }

        public async Task<MauSacResponse> AddMauSac(MauSacAddRequest? mauSacAddRequest)
        {
            if(mauSacAddRequest == null)
                throw new ArgumentNullException(nameof(mauSacAddRequest));

            MauSac? mauSac = mauSacAddRequest.ToMauSac();
            mauSac.ID_MauSac = Guid.NewGuid();

            await _mauSacRepository.AddMauSac(mauSac);
            return mauSac.ToMauSacResponse();
        }
    }
}
