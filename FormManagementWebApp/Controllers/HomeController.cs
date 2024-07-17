using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using FormManagementWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using FormManagementWebApp.Models;
using FormManagementWebApp.Models.Domain;

namespace FormManagementWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly FormDbContext _context;
    private readonly INotyfService _notyf;

    public HomeController(ILogger<HomeController> logger, FormDbContext context, INotyfService notyf)
    {
        _logger = logger;
        _context = context;
        _notyf = notyf;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> LoginPost(RegisterViewModel registerReq)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == registerReq.Email && u.Password == registerReq.Password);
            if (user != null)
            {
                user.IsLoggedIn = true;
                await _context.SaveChangesAsync();
                _notyf.Success("User logged in successfully!");
                return RedirectToAction("Index");
            }
            else
            {
                //show toast
                _notyf.Error("Invalid credentials");
            }
        }
            
        return View("Login", registerReq);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> RegisterPost(RegisterViewModel registerViewRequest)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                Email = registerViewRequest.Email,
                Password = registerViewRequest.Password,
                Username = registerViewRequest.Username
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            _notyf.Success("User registered successfully!");
            return RedirectToAction("Login");
        }
        
        return View("Login", registerViewRequest);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()    
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
}