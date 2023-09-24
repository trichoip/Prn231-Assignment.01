using EStore.BusinessObject.Entities;
using EStore.Share.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EStore.Client.Pages.Products
{
    public class EditModel : PageModel
    {
        string url = "https://localhost:7240/api";
        HttpClient client;

        public EditModel()
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

            response = await client.GetAsync($"{url}/category");
            if (!response.IsSuccessStatusCode) return NotFound();
            var Categories = await response.Content.ReadFromJsonAsync<List<CategoryDTO>>();

            ViewData["CategoryId"] = new SelectList(Categories, "CategoryId", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await client.PutAsJsonAsync($"{url}/product/{Product.ProductId}", Product);

            if (!response.IsSuccessStatusCode) return NotFound();

            return RedirectToPage("./Index");
        }
    }
}
