using EStore.BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EStore.Client.Pages.Products
{
    public class DetailsModel : PageModel
    {
        string url = "https://localhost:7240/api";
        HttpClient client;

        public DetailsModel()
        {
            client = new HttpClient();
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var response = await client.GetAsync($"{url}/product/{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            Product = await response.Content.ReadFromJsonAsync<Product>();
            return Page();
        }
    }
}
