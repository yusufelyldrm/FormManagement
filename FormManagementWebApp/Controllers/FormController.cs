using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using FormManagementWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FormManagementWebApp.Models;
using FormManagementWebApp.Models.Domain;
using FormManagementWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FormManagementWebApp.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
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

        
        
        [HttpPost("CreateForm")]
        public async Task<IActionResult> CreateForm([FromBody] FormRequestModel formReq)
        {
            if (formReq == null)
            {
                return BadRequest("Invalid request body");
            }

            var form = new Form
            {
                Id = Guid.NewGuid(),
                Name = formReq.Name,
                Description = formReq.Description,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = Guid.NewGuid(),
                Fields = formReq.Fields.Select(f => new Field
                {
                    Id = Guid.NewGuid(),
                    Name = f.Name,
                    Required = f.Required,
                    DataType = Enum.Parse<DataTypeEnum>(f.DataType)
                }).ToList()
            };

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
       
        [HttpGet("Search")]
        public IActionResult Search(string query)
        {
            var _forms = _context.Forms.ToList();
            if (string.IsNullOrWhiteSpace(query))
            {
                return Ok(_forms); 
            }

            var filteredForms = _forms.Where(f => f.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(filteredForms);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var form = await _context.Forms.Include(f => f.Fields).FirstOrDefaultAsync(f => f.Id == id);
            if (form == null)
            {
                return NotFound();
            }
            return Ok(form);
        }
    }
}