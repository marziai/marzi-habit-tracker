namespace HabitTracker.Domain;

public class Habit
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime UpdatedAtUtc { get; set; }

    public ICollection<HabitLog> HabitLogs { get; set; } = new List<HabitLog>();
}
