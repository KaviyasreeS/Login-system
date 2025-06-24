using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalSystemAPI.Pages
{
    public class WelcomeModel : PageModel
    {
        public string Name { get; set; } = "User";

        public void OnGet(string name)
        {
            Name = string.IsNullOrEmpty(name) ? "User" : name;
        }
    }
}