using HabitTracker.Domain;

namespace HabitTracker.Application.Services;

public class StreakCalculatorService
{
    public (int currentStreak, int longestStreak) Calculate(IEnumerable<DateOnly> dates, DateOnly today)
    {
        var ordered = dates.Distinct().OrderBy(d => d).ToList();
        if (!ordered.Any()) return (0, 0);

        int longest = 0;
        int current = 0;
        int running = 1;
        DateOnly prev = ordered[0];
        longest = 1;

        for (int i = 1; i < ordered.Count; i++)
        {
            var d = ordered[i];
            if ((d.ToDateTime(TimeOnly.MinValue) - prev.ToDateTime(TimeOnly.MinValue)).TotalDays == 1)
            {
                running++;
            }
            else
            {
                if (running > longest) longest = running;
                running = 1;
            }
            prev = d;
        }

        if (running > longest) longest = running;

        // calculate current streak ending at today
        current = 0;
        for (int i = ordered.Count - 1; i >= 0; i--)
        {
            var d = ordered[i];
            var diff = (today.ToDateTime(TimeOnly.MinValue) - d.ToDateTime(TimeOnly.MinValue)).TotalDays;
            if (diff < 0) continue; // future dates ignored
            if (diff == current) // next consecutive day back
            {
                current++;
            }
            else if (diff == current + 1)
            {
                // gap larger than expected, stop
                break;
            }
            else if (diff > current + 1)
            {
                break;
            }
        }

        return (current, longest);
    }
}
