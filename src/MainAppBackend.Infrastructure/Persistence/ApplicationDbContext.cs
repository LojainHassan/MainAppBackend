using MainAppBackend.Domain.Entities.ClientLookup;

using MainAppBackend.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MainAppBackend.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    public DbSet<ClientLookup> ClientLookups => Set<ClientLookup>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}