using Microsoft.AspNetCore.Mvc;
using KhmerFestivalWebsite.Models;
using KhmerFestivalWebsite.Services;

namespace KhmerFestivalWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IFestivalService _festivalService;
        private readonly INewsService _newsService;

        public AdminController(IFestivalService festivalService, INewsService newsService)
        {
            _festivalService = festivalService;
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Festival Management
        public async Task<IActionResult> Festivals()
        {
            var festivals = await _festivalService.GetAllFestivalsAsync();
            return View(festivals);
        }

        public IActionResult CreateFestival()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFestival(Festival festival)
        {
            if (ModelState.IsValid)
            {
                await _festivalService.CreateFestivalAsync(festival);
                TempData["Success"] = "Thêm lễ hội thành công!";
                return RedirectToAction(nameof(Festivals));
            }
            return View(festival);
        }

        public async Task<IActionResult> EditFestival(string id)
        {
            var festival = await _festivalService.GetFestivalByIdAsync(id);
            if (festival == null) return NotFound();
            return View(festival);
        }

        [HttpPost]
        public async Task<IActionResult> EditFestival(Festival festival)
        {
            if (ModelState.IsValid)
            {
                await _festivalService.UpdateFestivalAsync(festival);
                TempData["Success"] = "Cập nhật lễ hội thành công!";
                return RedirectToAction(nameof(Festivals));
            }
            return View(festival);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFestival(string id)
        {
            await _festivalService.DeleteFestivalAsync(id);
            TempData["Success"] = "Xóa lễ hội thành công!";
            return RedirectToAction(nameof(Festivals));
        }

        // News Management
        public async Task<IActionResult> News()
        {
            var news = await _newsService.GetAllNewsAsync();
            return View(news);
        }

        public IActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews(News news)
        {
            if (ModelState.IsValid)
            {
                await _newsService.CreateNewsAsync(news);
                TempData["Success"] = "Thêm tin tức thành công!";
                return RedirectToAction(nameof(News));
            }
            return View(news);
        }

        public async Task<IActionResult> EditNews(string id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if (news == null) return NotFound();
            return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> EditNews(News news)
        {
            if (ModelState.IsValid)
            {
                await _newsService.UpdateNewsAsync(news);
                TempData["Success"] = "Cập nhật tin tức thành công!";
                return RedirectToAction(nameof(News));
            }
            return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNews(string id)
        {
            await _newsService.DeleteNewsAsync(id);
            TempData["Success"] = "Xóa tin tức thành công!";
            return RedirectToAction(nameof(News));
        }
    }
}