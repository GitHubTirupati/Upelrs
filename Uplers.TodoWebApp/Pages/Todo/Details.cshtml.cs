using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Uplers.TodoWebApp.Pages.Todo
{
    public class DetailsModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public DetailsModel(IHttpClientFactory client)
        {
            this.client = client;
        }

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
            return Page();
        }
    }
}
