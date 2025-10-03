/*
    Data Transferable Object:
        - En "ren" klasse til at sende data gennem API
        - Må ikke indeholde Id, da det typisk har Auto-Increment (Auto-Indsæt)
        - Beskytter database-modellen og gør API mere fleksibelt
*/

public class AddCerealDto
{
    // Værdier der er vigtige for databasen. VIGTIGT: Intet Id, ellers så fejl indlæses data
    public string? Name { get; set; }
    public string? Mfr { get; set; }
    public string? Type { get; set; }
    public int Calories { get; set; }
    public int Protein { get; set; }
    public int Fat { get; set; }
    public int Sodium { get; set; }
    public float Fiber { get; set; }
    public float Carbo { get; set; }
    public int Sugars { get; set; }
    public int Potass { get; set; }
    public int Vitamins { get; set; }
    public int Shelf { get; set; }
    public float Weight { get; set; }
    public float Cups { get; set; }
    public float Rating { get; set; }
}