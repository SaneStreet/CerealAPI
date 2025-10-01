using Microsoft.EntityFrameworkCore;

public class CerealDbContext : DbContext
{
    public DbSet<Cereal> Cereal { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connStr = "Server=localhost;Database=cerealdb;User=root;Password=123456";
        optionsBuilder.UseMySQL(connStr);
    }
    
}