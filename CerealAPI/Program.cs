using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
// Creates Swagger Gen
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Gets ConnectionString
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Adds DbContext, using MySQL
builder.Services.AddDbContext<CerealDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Local API urls
//builder.WebHost.UseUrls("http://+:5556");

// Builds the application
var app = builder.Build();

// 👇 Retry logic for MySQL
var retries = 10;
while (retries > 0)
{
    try
    {
        using var connection = new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        Console.WriteLine("Connected to MySQL!");
        break;
    }
    catch
    {
        retries--;
        Console.WriteLine("MySQL not ready, waiting 2s to retry...");
        Thread.Sleep(2000);
    }
}

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
    // Swagger calls
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use HTTPS, if necessary
app.UseHttpsRedirection();
// Maps the controller endpoints
app.MapControllers();

app.Run();
