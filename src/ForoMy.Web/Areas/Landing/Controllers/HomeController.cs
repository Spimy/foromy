using System.Diagnostics;
using ForoMy.Web.Areas.Landing.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForoMy.Web.Areas.Landing.Controllers;

[Area("Landing")]
public class HomeController : Controller
{
  public IActionResult Index()
  {
    return View();
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