using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_NET105.Controllers
{
    public class MauSacController : Controller
    {
        private readonly IMauSacAddService _mauSacAddService;
        private readonly IMauSacGetService _mauSacGetService;
        private readonly IMauSacSortService _mauSacSortService;
        private readonly IMauSacUpdateService _mauSacUpdateService;

        public MauSacController(IMauSacAddService mauSacAddService, IMauSacGetService mauSacGetService,
            IMauSacSortService mauSacSortService, IMauSacUpdateService mauSacUpdateService)
        {
            _mauSacAddService = mauSacAddService;
            _mauSacGetService = mauSacGetService;
            _mauSacSortService = mauSacSortService;
            _mauSacUpdateService = mauSacUpdateService;
        }

        public async Task<IActionResult> Index(string searchBy, string? searchString, string sortBy = nameof(MauSacResponse.TenMauSac), SortOrderOptions sortOrder = SortOrderOptions.ASC)
        {
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                { nameof(MauSacResponse.TenMauSac), "Tên màu sắc"},
                { nameof(MauSacResponse.MoTa), "Mô tả"},
                { nameof(MauSacResponse.TrangThai), "Trạng Thái"}
            };

            List<MauSacResponse> mauSacs = await _mauSacGetService.GetFilterdMauSac(searchBy, searchString);
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.SearchString = searchString;

            List<MauSacResponse> sortedMauSacs = await _mauSacSortService.GetSortMauSac(mauSacs, sortBy, sortOrder);
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSortOrder = sortOrder.ToString();

            return View(sortedMauSacs);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<MauSacResponse> mauSacs = await _mauSacGetService.GetAllMauSac();
            ViewBag.MauSac = mauSacs.Select(temp => new SelectListItem()
            {
                Text = temp.TenMauSac,
                Value = temp.ID_MauSac.ToString()
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MauSacAddRequest mauSacAddRequest)
        {
            if (!ModelState.IsValid)
            {
                List<MauSacResponse> mauSacs = await _mauSacGetService.GetAllMauSac();
                ViewBag.MauSac = mauSacs.Select(temp =>
                new SelectListItem()
                {
                    Text = temp.TenMauSac,
                    Value = temp.ID_MauSac.ToString()
                });

                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(mauSacAddRequest);
            }

            MauSacResponse mauSacResponse = await _mauSacAddService.AddMauSac(mauSacAddRequest);

            return RedirectToAction("Index", "MauSac");
        }
    }
}
