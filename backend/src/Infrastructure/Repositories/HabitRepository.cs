using HabitTracker.Domain;
using HabitTracker.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Infrastructure.Repositories;

public class HabitRepository
{
    private readonly AppDbContext _db;

    public HabitRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Habit> CreateAsync(Habit habit)
    {
        habit.CreatedAtUtc = DateTime.UtcNow;
        habit.UpdatedAtUtc = DateTime.UtcNow;
        _db.Habits.Add(habit);
        await _db.SaveChangesAsync();
        return habit;
    }

    public async Task<Habit?> GetAsync(int id) => await _db.Habits.Include(h => h.HabitLogs).FirstOrDefaultAsync(h => h.Id == id);

    public async Task<List<Habit>> ListAsync() => await _db.Habits.Include(h => h.HabitLogs).ToListAsync();

    public async Task UpdateAsync(Habit habit)
    {
        habit.UpdatedAtUtc = DateTime.UtcNow;
        _db.Habits.Update(habit);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var h = await _db.Habits.FindAsync(id);
        if (h != null)
        {
            _db.Habits.Remove(h);
            await _db.SaveChangesAsync();
        }
    }
}
