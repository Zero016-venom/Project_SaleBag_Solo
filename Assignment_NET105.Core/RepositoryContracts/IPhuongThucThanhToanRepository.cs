using Assignment_NET105.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.RepositoryContracts
{
    public interface IPhuongThucThanhToanRepository
    {
        Task<PTTT> AddPhuongThucThanhToan(PTTT phuongThucThanhToan);

        Task<PTTT> UpdatePhuongThucThanhToan(PTTT phuongThucThanhToan);

        Task<List<PTTT>> GetAllPhuongThucThanhToan();

        Task<PTTT?> GetPhuongThucThanhToanByPTTTID(Guid phuongThucThanhToanID);

        Task<PTTT?> GetPhuongThucThanhToanByTenPTTT(string? tenPhuongThucThanhToan);

        Task<List<PTTT>> GetFilteredPhuongThucThanhToan(Expression<Func<PTTT, bool>> predicate);
    }
}
