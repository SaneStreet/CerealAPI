#🌾 CerealsAPI

Et simpelt ASP.NET Core Web API projekt, der demonstrerer hvordan man kan bygge en REST API med Entity Framework Core og dokumentere den med Swagger.

##🚀 Teknologier

- ASP.NET Core Web API
- Entity Framework Core
- MySQL Workbench
- Swagger / Swashbuckle

##📦 Krav
- .NET 8 SDK
- MySQL database (eller anden EF Core understøttet databadase)

##⚙️ Installation

1. Klon repoet:
```
git clone https://github.com/brugernavn/CerealsAPI.git
cd CerealsAPI
```
2. Tilføj database-forbindelse i ```appsettings.json``` :
```
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=cerealsdb;user=root;password=dinKode"
  }
```
3. Kør database migrationer:
```
dotnet ef database update
```
4. Start API'et enten i Visual Studio Run eller .NET CLI:
```
dotnet run
```
##📖 Brug af Swagger

Når API’et kører, kan du åbne:
```
https://localhost:5555/swagger
```
Her kan du se og teste alle endpoints i browseren.

##🗂 Eksempel: Model og Endpoint
<b>Model (Cereal.cs)</b>:
```
public class Cereal
{
    public int Id {get; set;}
    public string Name {get; set;}
    public float Calories {get; set;}
}
```
<b>Controller (CerealsController.cs)</b>:
```
[ApiController]
[Route("api/[controller]")]
public class CerealsController : ControllerBase
{
    private readonly AppDbContext _context;

    public CerealsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cereal>>> GetCereals()
        => await _context.Cereals.ToListAsync();
}
```
##🧪 Test

Kald API’et fra terminalen:
```
curl https://localhost:5555/api/cereals
```
Eller benyt Swagger til GET/POST requests.
