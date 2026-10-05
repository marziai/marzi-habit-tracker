namespace HabitTracker.API.Models;

public class CreateHabitRequest
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}
