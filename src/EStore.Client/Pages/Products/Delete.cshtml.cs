using EStore.BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EStore.Client.Pages.Products
{
    public class DeleteModel : PageModel
    {
        string url = "https://localhost:7240/api";
        HttpClient client;

        public DeleteModel()
        {
            client = new HttpClient();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var response = await client.GetAsync($"{url}/product/{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            Product = await response.Content.ReadFromJsonAsync<Product>();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var response = await client.DeleteAsync($"{url}/product/{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            return RedirectToPage("./Index");
        }
    }
}
