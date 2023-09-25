using EStore.Share.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EStore.Client.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public LoginRequest LoginRequest { get; set; }

        string url = "https://localhost:7240/api";
        HttpClient client;

        public IndexModel()
        {
            client = new HttpClient();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var response = await client.PostAsJsonAsync($"{url}/Member/Login", LoginRequest);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("LoginRequest.Password", "Invalid login attempt.");
                return Page();
            }

            return RedirectToPage("/Products/index");
        }
    }
}