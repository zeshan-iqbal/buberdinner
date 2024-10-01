using BuberDinner.Domain.MenuAggregate;

using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence;

internal class BuberDinnerDbContext: DbContext
{
    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Menu> Menus { get; set; }
}