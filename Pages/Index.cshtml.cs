using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalSystemAPI.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet(string msg)
        {
            Message = msg ?? "Welcome to the Home Page!";
        }
    }
}
