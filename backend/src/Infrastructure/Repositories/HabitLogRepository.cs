using HabitTracker.Domain;
using HabitTracker.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Infrastructure.Repositories;

public class HabitLogRepository
{
    private readonly AppDbContext _db;

    public HabitLogRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<HabitLog> CreateAsync(HabitLog log)
    {
        log.CreatedAtUtc = DateTime.UtcNow;
        _db.HabitLogs.Add(log);
        await _db.SaveChangesAsync();
        return log;
    }

    public async Task<List<HabitLog>> ListForHabitAsync(int habitId) => await _db.HabitLogs.Where(l => l.HabitId == habitId).ToListAsync();

    public async Task<bool> ExistsAsync(int habitId, DateOnly date) => await _db.HabitLogs.AnyAsync(l => l.HabitId == habitId && l.LogDate == date);

    public async Task DeleteAsync(int id)
    {
        var l = await _db.HabitLogs.FindAsync(id);
        if (l != null)
        {
            _db.HabitLogs.Remove(l);
            await _db.SaveChangesAsync();
        }
    }
}
