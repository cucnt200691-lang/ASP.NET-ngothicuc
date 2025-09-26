using Microsoft.AspNetCore.Mvc;
using KhmerFestivalWebsite.Services;

namespace KhmerFestivalWebsite.Controllers;

public class FestivalsController : Controller
{
    private readonly IFestivalService _festivalService;

    public FestivalsController(IFestivalService festivalService)
    {
        _festivalService = festivalService;
    }

    public async Task<IActionResult> Index(string search)
    {
        var festivals = string.IsNullOrEmpty(search) 
            ? await _festivalService.GetAllFestivalsAsync()
            : await _festivalService.SearchFestivalsAsync(search);
            
        ViewBag.SearchQuery = search;
        return View(festivals);
    }

    public async Task<IActionResult> Details(string id)
    {
        if (string.IsNullOrEmpty(id))
            return NotFound();

        var festival = await _festivalService.GetFestivalByIdAsync(id);
        if (festival == null)
            return NotFound();

        return View(festival);
    }
}