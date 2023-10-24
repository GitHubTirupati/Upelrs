using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Uplers.TodoWebApp.Pages.Todo
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public EditModel(IHttpClientFactory client)
        {
            this.client = client;
        }

        [BindProperty]
        public Models.APIViewModels.Todo todo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.CreateClient("client").GetStringAsync("todoitems/" + id);
            todo = JsonConvert.DeserializeObject<Models.APIViewModels.Todo>(response);

            if (todo == null)
            {
                return NotFound();
            }

            // Select current DepartmentID.
            var response_dep = await client.CreateClient("client").GetStringAsync("todoitems");
            var dep = JsonConvert.DeserializeObject<List<Models.APIViewModels.Todo>>(response_dep);
            ViewData["TodoID"] = new SelectList((System.Collections.IEnumerable)dep, "ID", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await client.CreateClient("client").PutAsync("todoitems/" + id, new StringContent(JsonConvert.SerializeObject(todo), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return RedirectToPage("./Index");
            else
                return RedirectToPage("/Error");
        }
    }
}
