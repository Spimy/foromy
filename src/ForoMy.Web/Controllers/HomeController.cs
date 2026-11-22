using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ForoMy.Web.Models;
using ForoMy.Core.Common.Interfaces;
using ForoMy.Core.Forums;
using ForoMy.Infrastructure.Persistence;

namespace ForoMy.Web.Controllers;

public class HomeController(ICurrentForum currentForum, ForoMyDbContext dbContext) : Controller
{
    public IActionResult Index()
    {
        if (currentForum.ForumId is null)
        {
            return View(new HomeViewModel());
        }

        var forum = dbContext.Forums.Where(forum => forum.Id == currentForum.ForumId).FirstOrDefault();
        if (forum is null)
        {
            return NotFound();
        }

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
