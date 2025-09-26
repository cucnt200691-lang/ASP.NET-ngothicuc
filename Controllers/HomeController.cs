using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KhmerFestivalWebsite.Models;
using KhmerFestivalWebsite.Services;

namespace KhmerFestivalWebsite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFestivalService _festivalService;
    private readonly INewsService _newsService;

    public HomeController(ILogger<HomeController> logger, IFestivalService festivalService, INewsService newsService)
    {
        _logger = logger;
        _festivalService = festivalService;
        _newsService = newsService;
    }

    public async Task<IActionResult> Index()
    {
        var festivals = await _festivalService.GetAllFestivalsAsync();
        var news = await _newsService.GetLatestNewsAsync(3);
        
        ViewBag.FeaturedFestivals = festivals.Take(6).ToList();
        ViewBag.LatestNews = news;
        ViewBag.TotalFestivals = festivals.Count;
        
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
