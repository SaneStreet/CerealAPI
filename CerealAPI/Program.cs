using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<ICerealRepository, CerealRepository>();
// henter connectionString
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Tilføjer DbContext med MySQL
builder.Services.AddDbContext<CerealDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CerealDbContext>();
    db.Database.Migrate(); // Opdater DB

    CerealSeeder.SeedProducts(db, "Data/Cereal.csv");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Swagger 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
