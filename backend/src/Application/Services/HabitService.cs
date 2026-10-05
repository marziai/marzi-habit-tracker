using HabitTracker.Domain;
using HabitTracker.Infrastructure.Repositories;

namespace HabitTracker.Application.Services;

public class HabitService
{
    private readonly HabitRepository _repo;

    public HabitService(HabitRepository repo)
    {
        _repo = repo;
    }

    public async Task<Habit> CreateAsync(string title, string? description)
    {
        var habit = new Habit
        {
            Title = title.Trim(),
            Description = description,
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        };

        return await _repo.CreateAsync(habit);
    }

    public async Task<List<Habit>> ListAsync() => await _repo.ListAsync();

    public async Task<Habit?> GetAsync(int id) => await _repo.GetAsync(id);

    public async Task UpdateAsync(int id, string title, string? description)
    {
        var h = await _repo.GetAsync(id);
        if (h == null) throw new KeyNotFoundException("Habit not found");
        h.Title = title.Trim();
        h.Description = description;
        await _repo.UpdateAsync(h);
    }

    public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
}
