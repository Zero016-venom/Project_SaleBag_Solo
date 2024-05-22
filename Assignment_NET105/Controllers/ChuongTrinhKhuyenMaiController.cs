using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_NET105.Controllers
{
    [Route("[controller]")]
    public class ChuongTrinhKhuyenMaiController : Controller
    {
        private readonly IChuongTrinhKhuyenMaiAddService _chuongTrinhKhuyenMaiAddService;
        private readonly IChuongTrinhKhuyenMaiGetService _chuongTrinhKhuyenMaiGetService;
        private readonly IChuongTrinhKhuyenMaiSortService _chuongTrinhKhuyenMaiSortService;
        private readonly IChuongTrinhKhuyenMaiUpdateService _chuongTrinhKhuyenMaiUpdateService;

        public ChuongTrinhKhuyenMaiController(IChuongTrinhKhuyenMaiAddService chuongTrinhKhuyenMaiAddService,
            IChuongTrinhKhuyenMaiGetService chuongTrinhKhuyenMaiGetService, IChuongTrinhKhuyenMaiSortService chuongTrinhKhuyenMaiSortService,
            IChuongTrinhKhuyenMaiUpdateService chuongTrinhKhuyenMaiUpdateService)
        {
            _chuongTrinhKhuyenMaiAddService = chuongTrinhKhuyenMaiAddService;
            _chuongTrinhKhuyenMaiGetService = chuongTrinhKhuyenMaiGetService;
            _chuongTrinhKhuyenMaiSortService = chuongTrinhKhuyenMaiSortService;
            _chuongTrinhKhuyenMaiUpdateService = chuongTrinhKhuyenMaiUpdateService;
        }

        [Route("[action]")]
        public async Task<IActionResult> Index(string searchBy, string? searchString, string sortBy = nameof(ChuongTrinhKhuyenMaiResponse.TenChuongTrinhKhuyenMai), SortOrderOptions sortOrder = SortOrderOptions.ASC)
        {
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                {nameof(ChuongTrinhKhuyenMaiResponse.TenChuongTrinhKhuyenMai), "Tên chương trình khuyến mại" },
                {nameof(ChuongTrinhKhuyenMaiResponse.NgayBatDau), "Ngày bắt đầu" },
                {nameof(ChuongTrinhKhuyenMaiResponse.NgayKetThuc), "Ngày kết thúc"},
                {nameof(ChuongTrinhKhuyenMaiResponse.TrangThai), "Trạng thái" },
                {nameof(ChuongTrinhKhuyenMaiResponse.ID_SanPham), "Sản phẩm" }
            };

            List<ChuongTrinhKhuyenMaiResponse> chuongTrinhKhuyenMais = await _chuongTrinhKhuyenMaiGetService.GetFilteredChuongTrinhKhuyenMai(searchBy, searchString);
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;

            List<ChuongTrinhKhuyenMaiResponse> sortedChuongTrinhKhuyenMais = await _chuongTrinhKhuyenMaiSortService.GetSortChuongTrinhKhuyenMai(chuongTrinhKhuyenMais, sortBy, sortOrder);
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSortOrder = sortOrder.ToString();

            return View(sortedChuongTrinhKhuyenMais);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<ChuongTrinhKhuyenMaiResponse> chuongTrinhKhuyenMais = await _chuongTrinhKhuyenMaiGetService.GetAllChuongTrinhKhuyenMai();
            ViewBag.ChuongTrinhKhuyenMai = chuongTrinhKhuyenMais.Select(temp => new SelectListItem()
            {
                Text = temp.TenChuongTrinhKhuyenMai,
                Value = temp.ID_ChuongTrinhKhuyenMai.ToString()
            });

            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(ChuongTrinhKhuyenMaiAddRequest chuongTrinhKhuyenMaiAddRequest)
        {
            if (!ModelState.IsValid)
            {
                List<ChuongTrinhKhuyenMaiResponse> chatLieus = await _chuongTrinhKhuyenMaiGetService.GetAllChuongTrinhKhuyenMai();
                ViewBag.ChuongTrinhKhuyenMai = chatLieus.Select(temp =>
                new SelectListItem()
                {
                    Text = temp.TenChuongTrinhKhuyenMai,
                    Value = temp.ID_ChuongTrinhKhuyenMai.ToString()
                });

                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(chuongTrinhKhuyenMaiAddRequest);
            }

            ChuongTrinhKhuyenMaiResponse chuongTrinhKhuyenMaiResponse = await _chuongTrinhKhuyenMaiAddService.AddChuongTrinhKhuyenMai(chuongTrinhKhuyenMaiAddRequest);

            return RedirectToAction("Index", "ChuongTrinhKhuyenMai");
        }
    }
}
