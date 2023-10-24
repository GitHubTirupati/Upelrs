using Uplers.TodoApi.Model;

namespace Uplers.TodoApi.Data
{
    public class DbInitializer
    {
        public async static Task Initialize(ApplicationDbContext context)
        {
            
            await context.Database.EnsureCreatedAsync();

            // Look for any todo lists.
            if (context.todosList.Any())
            {
                return;   // DB has been seeded
            }

           

            var todo = new Todo[]
            {
                new Todo { Name = "EnglishTask", IsComplete = true},
                new Todo { Name = "MathsTask", IsComplete = true},

            };

            await context.todosList.AddRangeAsync(todo);
            await context.SaveChangesAsync();


            
        }
    }
}
