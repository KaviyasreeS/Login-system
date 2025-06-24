using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using HospitalSystemAPI.Data;

namespace HospitalSystemAPI.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;
        public LoginModel(AppDbContext context) => _context = context;

        [BindProperty, Required, EmailAddress]
        public string Email { get; set; }

        [BindProperty, Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = _context.Patients.FirstOrDefault(p => p.Email == Email && p.Password == Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return Page();
            }

            return RedirectToPage("/Welcome", new { name = user.Name });
        }
    }
}