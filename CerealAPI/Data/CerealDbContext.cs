using Microsoft.EntityFrameworkCore;

public class CerealDbContext : DbContext
{

    public CerealDbContext(DbContextOptions<CerealDbContext> options) : base(options) { }

    public DbSet<Cereal> Cereals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}