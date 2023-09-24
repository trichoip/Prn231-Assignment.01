using EStore.Share.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EStore.Client.Pages.Products
{
    public class IndexModel : PageModel
    {
        string url = "https://localhost:7240/api";
        HttpClient client;

        public IndexModel()
        {
            client = new HttpClient();
        }

        public IList<ProductDTO> Product { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string search { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {

            var response = await client.GetAsync($"{url}/Product?search={search}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            Product = await response.Content.ReadFromJsonAsync<List<ProductDTO>>();
            return Page();
        }
    }
}
