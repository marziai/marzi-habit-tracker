namespace HabitTracker.Domain;

public class HabitLog
{
    public int Id { get; set; }
    public int HabitId { get; set; }
    public DateOnly LogDate { get; set; }
    public DateTime CreatedAtUtc { get; set; }

    public Habit Habit { get; set; } = null!;
}
