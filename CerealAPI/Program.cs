using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
// Tilføjer Swagger Gen
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Henter ConnectionString
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Tilføjer DbContext med MySQL
builder.Services.AddDbContext<CerealDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Bygger applikationen
var app = builder.Build();

// Sætter scope på hvilken database og migrationer der skal bruges
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CerealDbContext>();
    db.Database.Migrate();
    // Tilføjer data fra .CSV ind i DB
    CerealSeeder.SeedProducts(db, "Data/Cereal.csv");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Swagger kald
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Hvis nødvendigt, går til HTTPS istedet
app.UseHttpsRedirection();
// Kortlæg controller endpoints
app.MapControllers();

app.Run();
