using System.Globalization;

/*
    Seeder:
        - Bruges til at fylde databasen med test- eller startdata, når API køres første gang.
        - Gør udvikling og demo nemmere, da man ikke starter med en tom database
*/


public static class CerealSeeder
{
    public static void SeedProducts(CerealDbContext context, string csvFilePath)
    {
        // Hvis filen ikke eksistere, så kom med en fejl
        if (!File.Exists(csvFilePath))
            throw new FileNotFoundException("CSV filen blev ikke fundet", csvFilePath);

        // Spring de første 2 linjer over (headers)
        var lines = File.ReadAllLines(csvFilePath).Skip(2);

        // For hver linje i filen, gør noget
        foreach (var line in lines)
        {
            // Hver linje skal "starte forfra" når ; er nået
            var parts = line.Split(';');
            // Hvis der er ugyldige rækker, så spring dem over
            if (parts.Length < 2)
                continue;

            // Et objekt der skal læses ind i DB
            var cereal = new Cereal
            {
                Name = parts[0].Trim(),
                Mfr = parts[1].Trim(),
                Type = parts[2].Trim(),
                Calories = int.Parse(parts[3].Trim()),
                Protein = int.Parse(parts[4].Trim()),
                Fat = int.Parse(parts[5].Trim()),
                Sodium = int.Parse(parts[6].Trim()),
                Fiber = float.Parse(parts[7].Trim()),
                Carbo = float.Parse(parts[8].Trim()),
                Sugars = int.Parse(parts[9].Trim()),
                Potass = int.Parse(parts[10].Trim()),
                Vitamins = int.Parse(parts[11].Trim()),
                Shelf = int.Parse(parts[12].Trim()),
                Weight = float.Parse(parts[13].Trim()),
                Cups = float.Parse(parts[14].Trim(), CultureInfo.InvariantCulture),
                Rating = float.Parse(parts[15].Trim(), CultureInfo.InvariantCulture)

            };

            // Kun tilføj hvis produktet ikke findes i forvejen
            if (!context.Cereals.Any(c => c.Name == cereal.Name))
            {
                context.Cereals.Add(cereal);
            }
        }

        // Gem ændringerne
        context.SaveChanges();
    }
}
