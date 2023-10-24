using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Uplers.TodoWebApp.Pages.Todo
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public IndexModel(IHttpClientFactory client)
        {
            this.client = client;
        }

        public List<Models.APIViewModels.Todo> todoResult { get; set; }

        public async Task OnGetAsync()
        {
            var response = await client.CreateClient("client").GetStringAsync("todoitems");
            todoResult = JsonConvert.DeserializeObject<List<Models.APIViewModels.Todo>>(response);
        }
    }
}
