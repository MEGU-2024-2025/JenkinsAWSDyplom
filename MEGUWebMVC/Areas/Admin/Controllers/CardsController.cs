using Microsoft.AspNetCore.Mvc;

namespace MEGUWebMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class CardsController : Controller
{
  public IActionResult Basic() => View();
}
