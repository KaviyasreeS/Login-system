// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using System.Net.Http;
// using System.Text;
// using System.Text.Json;
// using HospitalSystemAPI.Models;

// namespace HospitalSystemAPI.Pages
// {
//     public class SignupModel : PageModel
//     {
//         [BindProperty]
//         public Patient Patient { get; set; }

//         public string Message { get; set; }

//         public async Task<IActionResult> OnPostAsync()
//         {
//             using var client = new HttpClient();
//             var json = JsonSerializer.Serialize(Patient);
//             var content = new StringContent(json, Encoding.UTF8, "application/json");

//             var response = await client.PostAsync("https://localhost:5031/api/patient/register", content);
//             Message = response.IsSuccessStatusCode
//                 ? "Registered successfully!"
//                 : await response.Content.ReadAsStringAsync();

//             return Page();
//         }
//     }
// }
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using HospitalSystemAPI.Models;

namespace HospitalSystemAPI.Pages
{
    public class SignupModel : PageModel
    {
        [BindProperty]
        public Patient Patient { get; set; }

        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Patient == null || string.IsNullOrWhiteSpace(Patient.Email) || string.IsNullOrWhiteSpace(Patient.Password))
            {
                Message = "Please fill all required fields.";
                return Page();
            }

            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(Patient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5031/api/patient/register", content);
            if (response.IsSuccessStatusCode)
            {
                Message = "Registered successfully!";
                return RedirectToPage("Login", new { msg = "Login successful!" });
            }

            Message = await response.Content.ReadAsStringAsync();
            return Page();
        }
    }
}
