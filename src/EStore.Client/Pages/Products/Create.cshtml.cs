using EStore.BusinessObject.Entities;
using EStore.Share.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EStore.Client.Pages.Products
{
    public class CreateModel : PageModel
    {
        string url = "https://localhost:7240/api";
        HttpClient client;

        public CreateModel()
        {
            client = new HttpClient();
        }
        public async Task<IActionResult> OnGetAsync()
        {

            var response = await client.GetAsync($"{url}/category");
            if (!response.IsSuccessStatusCode) return NotFound();
            var Categories = await response.Content.ReadFromJsonAsync<List<CategoryDTO>>();

            ViewData["CategoryId"] = new SelectList(Categories, "CategoryId", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await client.PostAsJsonAsync($"{url}/product", Product);
            if (!response.IsSuccessStatusCode) return NotFound();

            return RedirectToPage("./Index");
        }
    }
}
