using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<CerealDbContext>(options =>
{
    //string connStr = "Server=localhost;Database=cerealdb;User=root;Password=123456";
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
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
