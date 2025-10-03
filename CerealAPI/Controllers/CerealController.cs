using Microsoft.AspNetCore.Mvc;

/*
    Controller til Cereals:
        - Styrer API endpoints (api/Cereal)
        - Modtager HTTP-requests (GET, POST, PUT, DELETE)
        - Kalder på DbContext eller en service/repository for at hente eller ændre data
        - Afleverer resultatet som JSON
*/

// tilføjer route: localhost:xxxx/api/Cereals
[Route("api/[controller]")]
[ApiController]
public class CerealController : Controller
{
    // DbContext forbindelse
    public readonly CerealDbContext _DbContext;

    public CerealController(CerealDbContext cerealDbContext)
    {
        _DbContext = cerealDbContext;
    }

    // Find alle Cereals
    [HttpGet]
    public IActionResult GetAllCereals()
    {
        var allCereals = _DbContext.Cereals.ToList();
        return Ok(allCereals);
    }

    // Find specifik Cereal på ID
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetCerealById(int id)
    {
        var cereal = _DbContext.Cereals.Find(id);
        if (cereal is null)
        {
            return NotFound();
        }

        return Ok(cereal);
    }

    // Indlæs ny Cereal
    [HttpPost]
    public IActionResult AddCereal(AddCerealDto addCerealDto)
    {
        var cerealEntity = new Cereal()
        {
            Name = addCerealDto.Name,
            Mfr = addCerealDto.Mfr,
            Type = addCerealDto.Type,
            Calories = addCerealDto.Calories,
            Protein = addCerealDto.Protein,
            Fat = addCerealDto.Fat,
            Sodium = addCerealDto.Sodium,
            Fiber = addCerealDto.Fiber,
            Carbo = addCerealDto.Carbo,
            Sugars = addCerealDto.Sugars,
            Potass = addCerealDto.Potass,
            Vitamins = addCerealDto.Vitamins,
            Shelf = addCerealDto.Shelf,
            Weight = addCerealDto.Weight,
            Cups = addCerealDto.Cups,
            Rating = addCerealDto.Rating
        };

        _DbContext.Cereals.Add(cerealEntity);
        _DbContext.SaveChanges();

        return Ok(cerealEntity);
    }

    // Opdater en Cereal på ID
    [HttpPut]
    [Route("{id:int}")]
    public IActionResult UpdateCereal(int id, UpdCerealDto updCerealDto)
    {
        var cereal = _DbContext.Cereals.Find(id);
        if (cereal is null)
            return NotFound();

        cereal.Name = updCerealDto.Name;
        cereal.Mfr = updCerealDto.Mfr;
        cereal.Type = updCerealDto.Type;
        cereal.Calories = updCerealDto.Calories;
        cereal.Protein = updCerealDto.Protein;
        cereal.Fat = updCerealDto.Fat;
        cereal.Sodium = updCerealDto.Sodium;
        cereal.Fiber = updCerealDto.Fiber;
        cereal.Carbo = updCerealDto.Carbo;
        cereal.Sugars = updCerealDto.Sugars;
        cereal.Potass = updCerealDto.Potass;
        cereal.Vitamins = updCerealDto.Vitamins;
        cereal.Shelf = updCerealDto.Shelf;
        cereal.Weight = updCerealDto.Weight;
        cereal.Cups = updCerealDto.Cups;
        cereal.Rating = updCerealDto.Rating;

        _DbContext.SaveChanges();

        return Ok(cereal);
    }

    // Slet et Cereal på ID
    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteCereal(int id)
    {
        var cereal = _DbContext.Cereals.Find(id);

        if (cereal is null)
            return NotFound();

        _DbContext.Cereals.Remove(cereal);
        _DbContext.SaveChanges();

        return Ok();
    }

}