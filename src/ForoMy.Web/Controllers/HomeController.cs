using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ForoMy.Web.Models;
using ForoMy.Core.Common.Interfaces;

namespace ForoMy.Web.Controllers;

public class HomeController(ICurrentForum currentForum) : Controller
{
    public IActionResult Index()
    {
        if (currentForum.Forum is not { } forum) return NotFound();
        return View(new HomeViewModel { ForumName = forum.Name });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
