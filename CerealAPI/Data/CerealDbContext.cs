using Microsoft.EntityFrameworkCore;

public class CerealDbContext : DbContext
{

    public CerealDbContext(DbContextOptions<CerealDbContext> options) : base(options)
    {
        
    }

    public DbSet<Cereal> Cereal { get; set; }

    
}