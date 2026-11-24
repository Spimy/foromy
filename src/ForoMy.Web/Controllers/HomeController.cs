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
}
