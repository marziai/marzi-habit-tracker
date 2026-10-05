using Microsoft.AspNetCore.Mvc;
using HabitTracker.Application.Services;
using HabitTracker.Domain;
using HabitTracker.API.Models;

namespace HabitTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitsController : ControllerBase
{
    private readonly HabitService _habitService;
    private readonly HabitLogService _logService;
    private readonly StreakCalculatorService _streakService;

    public HabitsController(HabitService habitService, HabitLogService logService, StreakCalculatorService streakService)
    {
        _habitService = habitService;
        _logService = logService;
        _streakService = streakService;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var habits = await _habitService.ListAsync();
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var result = habits.Select(h => new 
        {
            id = h.Id,
            title = h.Title,
            description = h.Description,
            createdAtUtc = h.CreatedAtUtc,
            updatedAtUtc = h.UpdatedAtUtc,
            isCompletedToday = h.HabitLogs.Any(l => l.LogDate == today),
            // derive streaks
            currentStreak = _streakService.Calculate(h.HabitLogs.Select(l => l.LogDate), today).currentStreak,
            longestStreak = _streakService.Calculate(h.HabitLogs.Select(l => l.LogDate), today).longestStreak
        });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHabitRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.Title)) return BadRequest("Title is required");
        var h = await _habitService.CreateAsync(req.Title, req.Description);
        return CreatedAtAction(nameof(Get), new { habitId = h.Id }, h);
    }

    [HttpGet("{habitId}")]
    public async Task<IActionResult> Get(int habitId)
    {
        var h = await _habitService.GetAsync(habitId);
        if (h == null) return NotFound();
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var dto = new 
        {
            id = h.Id,
            title = h.Title,
            description = h.Description,
            createdAtUtc = h.CreatedAtUtc,
            updatedAtUtc = h.UpdatedAtUtc,
            isCompletedToday = h.HabitLogs.Any(l => l.LogDate == today),
            currentStreak = _streakService.Calculate(h.HabitLogs.Select(l => l.LogDate), today).currentStreak,
            longestStreak = _streakService.Calculate(h.HabitLogs.Select(l => l.LogDate), today).longestStreak
        };
        return Ok(dto);
    }

    [HttpPut("{habitId}")]
    public async Task<IActionResult> Update(int habitId, UpdateHabitRequest req)
    {
        try
        {
            await _habitService.UpdateAsync(habitId, req.Title ?? string.Empty, req.Description);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{habitId}")]
    public async Task<IActionResult> Delete(int habitId)
    {
        await _habitService.DeleteAsync(habitId);
        return NoContent();
    }
}
