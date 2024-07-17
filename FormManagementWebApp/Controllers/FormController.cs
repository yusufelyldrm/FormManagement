using AspNetCoreHero.ToastNotification.Abstractions;
using FormManagementWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FormManagementWebApp.Models;
using FormManagementWebApp.Models.Domain;
using FormManagementWebApp.Models.ViewModels;

namespace FormManagementWebApp.Controllers
{
    public class FormController : Controller
    {
        private readonly ILogger<FormController> _logger;
        private readonly FormDbContext _context;
        private readonly INotyfService _notyf;

        public FormController(ILogger<FormController> logger, FormDbContext context, INotyfService notyf)
        {
            _logger = logger;
            _context = context;
            _notyf = notyf;
        }

        [HttpGet]
        public async Task<IActionResult> Form()
        {
            var forms = await _context.Forms.ToListAsync();
            return View(forms);
        }

        [HttpPost]
        public async Task<IActionResult> CreateForm(FormViewModel formReq)
        {
            var form = new Form
            {
                Name = formReq.Name,
                Description = formReq.Description,
                CreatedAt = DateTime.Now,
                CreatedBy =
                    new Guid(), // Bu alanı ekledim, JSON verisinde createdBy var. Ama hangi kullanıcının oluşturduğunu bilmem için response olarak session göndermem gerekiyor.
            };

            // Fields eklemek için bir döngü
            foreach (var fieldVm in formReq.Fields)
            {
                var field = new Field
                {
                    Name = fieldVm.Name,
                    Required = fieldVm.Required,
                    DataType = Enum.Parse<DataType>(fieldVm.DataType) // DataType enum'a dönüştürme
                };
                form.Fields.Add(field);
            }

            if (ModelState.IsValid)
            {
                _context.Forms.Add(form);
                await _context.SaveChangesAsync();
                _notyf.Success("Form created successfully!");
                return RedirectToAction("Form");
            }

            var forms = await _context.Forms.ToListAsync();

            return View("Form", forms);
        }
        
        public IActionResult Details(Guid id)
        {
            var form = _context.Forms.FirstOrDefault(f => f.Id == id);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

    }
}