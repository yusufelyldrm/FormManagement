using Microsoft.AspNetCore.Mvc;

namespace FormManagementWebApp.Controllers;

public class FormController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}