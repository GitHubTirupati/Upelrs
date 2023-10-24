using Newtonsoft.Json;

namespace Uplers.TodoWebApp.Models.APIViewModels
{
    public class Todo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("isComplete")]
        public bool IsComplete { get; set; } = false;
    }
}
