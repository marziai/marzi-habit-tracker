using HabitTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Habit> Habits => Set<Habit>();
    public DbSet<HabitLog> HabitLogs => Set<HabitLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Habit>(entity =>
        {
            entity.HasKey(h => h.Id);
            entity.Property(h => h.Title)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(h => h.Description)
                .HasMaxLength(1000);
            entity.Property(h => h.CreatedAtUtc)
                .IsRequired();
            entity.Property(h => h.UpdatedAtUtc)
                .IsRequired();

            entity.HasMany(h => h.HabitLogs)
                .WithOne(l => l.Habit)
                .HasForeignKey(l => l.HabitId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<HabitLog>(entity =>
        {
            entity.HasKey(l => l.Id);
            entity.Property(l => l.LogDate)
                .IsRequired();
            entity.Property(l => l.CreatedAtUtc)
                .IsRequired();

            entity.HasIndex(l => new { l.HabitId, l.LogDate })
                .IsUnique();
        });
    }
}
