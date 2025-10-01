public static class CerealSeeder
{

    private static float ParseFloat(string str)
    {
        // Fjern tusindtals-separatorer
        var clean = str.Replace(".", "").Replace(",", ".");
        return float.TryParse(clean, out float val) ? val : 0;    
    }
    public static void SeedProducts(CerealDbContext context, string csvFilePath)
    {

        if (!File.Exists(csvFilePath))
            throw new FileNotFoundException("CSV filen blev ikke fundet", csvFilePath);

        var lines = File.ReadAllLines(csvFilePath).Skip(1); // Skipper header

        foreach (var line in lines)
        {

            var parts = line.Split(';');

            if (parts.Length < 2)
                continue; // spring over ugyldige rækker

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
                Cups = float.Parse(parts[14].Trim()),
                Rating = ParseFloat(parts[15].Trim())

            };

            // Kun tilføj hvis produktet ikke findes i forvejen
            if (!context.Cereal.Any(p => p.Name == cereal.Name))
            {
                context.Cereal.Add(cereal);
            }
        }

        context.SaveChanges();
    }
}
