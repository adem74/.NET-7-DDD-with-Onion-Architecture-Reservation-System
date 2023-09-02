using Dinner.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace Dinner.Infrastructure.Persistence;
public class DinnerDbContext : DbContext
{
    public DinnerDbContext(DbContextOptions<DinnerDbContext> options) : base(options)
    {

    }
    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DinnerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
} 