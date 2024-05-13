using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Assignment_NET105.Controllers
{
    [Route("[controller]")]
    public class ChatLieuController : Controller
    {
        private readonly IChatLieuAddService _chatLieuAddService;
        private readonly IChatLieuGetService _chatLieuGetService;
        private readonly IChatLieuSortService _chatLieuSortService;
        private readonly IChatLieuUpdateService _chatLieuUpdateService;


        public ChatLieuController(IChatLieuGetService chatLieuGetService, IChatLieuAddService chatLieuAddService,
            IChatLieuSortService chatLieuSortService, IChatLieuUpdateService chatLieuUpdateService)
        {
            _chatLieuAddService = chatLieuAddService;
            _chatLieuGetService = chatLieuGetService;
            _chatLieuSortService = chatLieuSortService;
            _chatLieuUpdateService = chatLieuUpdateService;
        }


        [Route("[action]")]
        public async Task<IActionResult> Index(string searchBy, string? searchString, string sortBy = nameof(ChatLieuResponse.TenChatLieu),
            SortOrderOptions sortOrder = SortOrderOptions.ASC)
        {
            //Search
            ViewBag.SearchFields = new Dictionary<string, string>()
                {
                  { nameof(ChatLieuResponse.TenChatLieu), "Tên chất liệu" },
                  { nameof(ChatLieuResponse.TrangThai), "Trạng thái" },
                  { nameof(ChatLieuResponse.MoTa), "Mô tả" },
                };

            List<ChatLieuResponse> chatLieus = await _chatLieuGetService.GetFilteredChatLieus(searchBy, searchString);
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;

            //Sort
            List<ChatLieuResponse> sortedChatLieus = await _chatLieuSortService.GetSortChatLieus(chatLieus, sortBy, sortOrder);
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSortOrder = sortOrder.ToString();

            return View(sortedChatLieus);
        }


        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<ChatLieuResponse> chatLieus = await _chatLieuGetService.GetAllChatLieu();
            ViewBag.ChatLieu = chatLieus.Select(temp => new SelectListItem()
            {
                Text = temp.TenChatLieu,
                Value = temp.ID_ChatLieu.ToString()
            });

            return View();
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(ChatLieuAddRequest chatLieuAddRequest)
        {
            if (!ModelState.IsValid)
            {
                List<ChatLieuResponse> chatLieus = await _chatLieuGetService.GetAllChatLieu();
                ViewBag.ChatLieu = chatLieus.Select(temp =>
                new SelectListItem()
                {
                    Text = temp.TenChatLieu,
                    Value = temp.ID_ChatLieu.ToString()
                });

                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(chatLieuAddRequest);
            }

            ChatLieuResponse chatLieuResponse = await _chatLieuAddService.AddChatLieu(chatLieuAddRequest);

            return RedirectToAction("Index", "ChatLieu");
        }


        [HttpGet]
        [Route("[action]/{ID_ChatLieu}")]
        public async Task<IActionResult> Edit(Guid ID_ChatLieu)
        {
            ChatLieuResponse? chatLieuResponse = await _chatLieuGetService.GetChatLieuByChatLieuID(ID_ChatLieu);
            if (chatLieuResponse == null)
            {
                return RedirectToAction("Index");
            }

            ChatLieuUpdateRequest chatLieuUpdateRequest = chatLieuResponse.ToChatLieuUpdateRequest();

            List<ChatLieuResponse> chatLieus = await _chatLieuGetService.GetAllChatLieu();
            ViewBag.ChatLieus = chatLieus.Select(temp => new SelectListItem()
            {
                Text = temp.TenChatLieu,
                Value = temp.ID_ChatLieu.ToString()
            });

            return View(chatLieuUpdateRequest);
        }

        [HttpPost]
        [Route("[action]/{ID_ChatLieu}")]
        public async Task<IActionResult> Edit(ChatLieuUpdateRequest chatLieuUpdateRequest)
        {
            ChatLieuResponse? chatLieuResponse = await _chatLieuGetService.GetChatLieuByChatLieuID(chatLieuUpdateRequest.ID_ChatLieu);
            if (chatLieuResponse == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                ChatLieuResponse updatedChatLieu = await _chatLieuUpdateService.UpdateChatLieu(chatLieuUpdateRequest);
                return RedirectToAction("Index");
            }
            else
            {
                List<ChatLieuResponse> chatLieus = await _chatLieuGetService.GetAllChatLieu();
                ViewBag.Countries = chatLieus.Select(temp =>
                new SelectListItem() 
                { 
                    Text = temp.TenChatLieu, 
                    Value = temp.ID_ChatLieu.ToString() 
                });

                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(chatLieuResponse.ToChatLieuUpdateRequest());
            }
        }
    }
}
