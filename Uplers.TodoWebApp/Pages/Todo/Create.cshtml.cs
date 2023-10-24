using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Uplers.TodoWebApp.Pages.Todo
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public CreateModel(IHttpClientFactory client)
        {
            this.client = client;
        }
        public async Task<IActionResult> OnGet()
        {
            var response = await client.CreateClient("client").GetStringAsync("todoitems");
            var dep = JsonConvert.DeserializeObject<List<Models.APIViewModels.Todo>>(response);
            ViewData["TodoID"] = new SelectList(dep, "ID", "Name");

            return Page();
        }
        [BindProperty]
        public Models.APIViewModels.Todo todo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await client.CreateClient("client").PostAsync("todoitems", new StringContent(JsonConvert.SerializeObject(todo), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return RedirectToPage("./Index");
            else
                return RedirectToPage("/Error");
        }
    }
}
