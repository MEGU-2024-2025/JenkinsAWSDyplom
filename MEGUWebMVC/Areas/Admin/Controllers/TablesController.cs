using Microsoft.AspNetCore.Mvc;

namespace MEGUWebMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class TablesController : Controller
{
  public IActionResult Basic() => View();
}
