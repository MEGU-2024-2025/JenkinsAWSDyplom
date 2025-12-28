using Microsoft.AspNetCore.Mvc;

namespace MEGUWebMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardsController : Controller
{
  public IActionResult Index() => View();
}
