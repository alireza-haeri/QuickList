namespace QuickList.App.Shared.Entities;

public class Todo
{
    public Guid Id { get; private set; }
    public string Task { get; private set; }
    public string Description { get; private set; }
    public DateTime CreateAt { get; private set; }

    public static Todo Create(string task, string Description) =>
        new() { Id = Guid.NewGuid(), Task = task, Description = Description };
}