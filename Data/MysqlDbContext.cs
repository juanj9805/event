using events.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace events.Data;

public class MysqlDbContext : DbContext
{
    public DbSet<EventModel> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var server = Environment.GetEnvironmentVariable("DB_SERVER");
        var database = Environment.GetEnvironmentVariable("DB_NAME");
        var user = Environment.GetEnvironmentVariable("DB_USER");
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

        var connectionString = $"server={server};database={database};user={user};password={password}";

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventModel>(ev =>
        {
            ev.Property(ev => ev.Id).IsRequired();
            ev.Property(ev => ev.Title).IsRequired();
            ev.Property(ev => ev.Img).IsRequired();
            ev.Property(ev => ev.Description).IsRequired();
            ev.Property(ev => ev.Location).IsRequired();
            ev.Property(ev => ev.Status).IsRequired();
            
            ev.Property(ev => ev.Date).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}


