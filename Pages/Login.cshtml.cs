using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using HospitalSystemAPI.Models;

namespace HospitalSystemAPI.Pages
{
    public class LoginModelPage : PageModel
    {
        [BindProperty]
        public LoginModel Login { get; set; }

        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(Login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:5031/api/patient/login", content);
            if (response.IsSuccessStatusCode)
            {
                Message = "Login successful!";
                return RedirectToPage("Index", new { msg = Message });
            }

            Message = await response.Content.ReadAsStringAsync();
            return Page();
        }
    }
}
