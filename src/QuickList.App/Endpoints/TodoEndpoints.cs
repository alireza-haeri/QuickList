using Microsoft.EntityFrameworkCore;
using QuickList.App.Shared;
using QuickList.App.Shared.Entities;

namespace QuickList.App.Endpoints;

public static class TodoEndpoints
{
    public static WebApplication MapTodoEndpoints(this WebApplication app)
    {
        var todoGroup = app.MapGroup("/api/todo");

        todoGroup.MapGet("", async (AppDbContext context, CancellationToken cancellationToken) =>
        {
            var data = await context.Todos
                .Select(t => new GetTodosModel(t.Id, t.Task, t.Description, t.CreateAt))
                .ToListAsync(cancellationToken: cancellationToken);
            return Results.Ok(data);
        });

        todoGroup.MapPost("", async (AppDbContext context, AddTodoModel model, CancellationToken cancellationToken) =>
        {
            var todo = Todo.Create(model.Task, model.Description);
            context.Add(todo);
            await context.SaveChangesAsync(cancellationToken);
            return Results.Created($"/api/todo/{todo.Id}",todo);
        });

        todoGroup.MapGet("{id:guid}", async (AppDbContext context,Guid id, CancellationToken cancellationToken) =>
        {
            var todo = await context.Todos.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if(todo is null) 
                return Results.NotFound();

            return Results.Ok(new GetTodoModel(todo.Id,todo.Task,todo.Description,todo.CreateAt));
        });

        return app;
    }

    private record GetTodosModel(Guid Id, string Task, string Description, DateTime CreateAt);
    private record GetTodoModel(Guid Id, string Task, string Description, DateTime CreateAt);

    private record AddTodoModel(string Task, string Description);
}