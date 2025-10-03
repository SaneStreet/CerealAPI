using Microsoft.EntityFrameworkCore;

/*
    DbContext:
        - "Broen" mellem kode og database
        - Indeholder DbSet for hver tabel i DB (name, weight, rating, etc)
        - Gemmer, henter og tracker ændringer i objekterne
    En "ORM" motor til EF Core.
*/

public class CerealDbContext : DbContext
{

    public CerealDbContext(DbContextOptions<CerealDbContext> options) : base(options) { }

    public DbSet<Cereal> Cereals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}