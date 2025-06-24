using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using HospitalSystemAPI.Models;
using HospitalSystemAPI.Data;

namespace HospitalSystemAPI.Pages
{

    public class RegisterModel : PageModel
    {
         private readonly AppDbContext _context;

    public RegisterModel(AppDbContext context)
    {
        _context = context;
    }

       

        [BindProperty]
        public Patient Patient { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Patients.Add(Patient);
            await _context.SaveChangesAsync();

            // Redirect to login or dashboard after success
            return RedirectToPage("/Login");
        }
    }
}