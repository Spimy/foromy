using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ForoMy.Web.Models;
using ForoMy.Core.Forums;
using ForoMy.Core.Common.Interfaces;

namespace ForoMy.Web.Controllers;

public class HomeController(IForumRepository forumRepository, ICurrentForum currentForum) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        if (currentForum.ForumId is not { } forumId) return NotFound();

        var forum = await forumRepository.FindByIdAsync(forumId, cancellationToken);
        if (forum is null) return NotFound();

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
