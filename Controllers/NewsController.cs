using Microsoft.AspNetCore.Mvc;
using KhmerFestivalWebsite.Services;

namespace KhmerFestivalWebsite.Controllers;

public class NewsController : Controller
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    public async Task<IActionResult> Index()
    {
        var news = await _newsService.GetAllNewsAsync();
        return View(news);
    }

    public async Task<IActionResult> Details(string id)
    {
        if (string.IsNullOrEmpty(id))
            return NotFound();

        var news = await _newsService.GetNewsByIdAsync(id);
        if (news == null)
            return NotFound();

        return View(news);
    }
}