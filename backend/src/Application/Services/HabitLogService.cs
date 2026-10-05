using HabitTracker.Domain;
using HabitTracker.Infrastructure.Repositories;

namespace HabitTracker.Application.Services;

public class HabitLogService
{
    private readonly HabitLogRepository _repo;

    public HabitLogService(HabitLogRepository repo)
    {
        _repo = repo;
    }

    public async Task<HabitLog> LogAsync(int habitId, DateOnly date)
    {
        var exists = await _repo.ExistsAsync(habitId, date);
        if (exists) throw new InvalidOperationException("Duplicate log for the same date");
        var log = new HabitLog
        {
            HabitId = habitId,
            LogDate = date,
            CreatedAtUtc = DateTime.UtcNow
        };
        return await _repo.CreateAsync(log);
    }

    public async Task<List<HabitLog>> ListForHabitAsync(int habitId) => await _repo.ListForHabitAsync(habitId);
}
