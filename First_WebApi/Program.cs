using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Console.WriteLine("Hello World!");

var todos = new List<Todo> ();

//get all
app.MapGet("/todos", () => todos);

//get todo
app.MapGet("/todos/{id}", Results<Ok<Todo>, NotFound> (int id) => {
    var targetTodo = todos.SingleOrDefault(t => t.Id == id);
    if (targetTodo is null)
        return TypedResults.NotFound();
    return TypedResults.Ok(targetTodo);
});

//create todo
app.MapPost("/todos", (Todo task) =>
{
    todos.Add(task);
    return TypedResults.Created("/todos/{id}", task);
});

//delete todo
app.MapDelete("/todos/{id}", (int id) =>
{
    todos.RemoveAll(t => t.Id == id);
    return TypedResults.NoContent();
});



app.Run();

public record Todo(int Id, string Name, DateTime DueDate, bool IsComplete);