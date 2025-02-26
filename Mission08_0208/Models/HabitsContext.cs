using Microsoft.EntityFrameworkCore;

namespace Mission08_0208.Models;

public class HabitsContext : DbContext
{
    // Keeps track of database context
    public HabitsContext(DbContextOptions<HabitsContext> options) : base(options) { }
    // For each model we create the connection
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    // This is for seeding data for the cateogories in the database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "School" },
            new Category { CategoryId = 3, CategoryName = "Work" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );
    }
}