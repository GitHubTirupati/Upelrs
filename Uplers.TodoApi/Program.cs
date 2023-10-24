using Microsoft.EntityFrameworkCore;
using Uplers.TodoApi.Data;
using Uplers.TodoApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlOptions => sqlOptions.EnableRetryOnFailure());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
await using (var scope = app.Services.CreateAsyncScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await DbInitializer.Initialize(db);
}
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


app.MapGet("/todoitems", async (ApplicationDbContext db) =>
    await db.todosList.ToListAsync());

app.MapGet("/todoitems/complete", async (ApplicationDbContext db) =>
    await db.todosList.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, ApplicationDbContext db) =>
    await db.todosList.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
: Results.NotFound());

app.MapPost("/todoitems", async (Todo todo, ApplicationDbContext db) =>
{
    db.todosList.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, ApplicationDbContext db) =>
{
    var todo = await db.todosList.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (int id, ApplicationDbContext db) =>
{
    if (await db.todosList.FindAsync(id) is Todo todo)
    {
        db.todosList.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
