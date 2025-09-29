using MySql.Data.MySqlClient;
using System.Globalization;

Console.Clear();
Console.WriteLine("~~~~~~ Start forbindelse ~~~~~~");
// Input fra bruger
Console.WriteLine("User: ");
string? user = Console.ReadLine();
Console.WriteLine("Pass: ");
string? password = null;
// Imens man taster vises password ikke (husk at taste korrekt) 
while (true)
{
    var key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.Enter)
        break;
    password += key.KeyChar;
}

// Forbindelse til cerealDB (MySQL)
string connStr = $"server=localhost;user={user};password={password};database=cerealdb";
using var conn = new MySqlConnection(connStr);
conn.Open();
Console.WriteLine(" Forbindelse oprettet.");

/* bool tableExists;
string sqlStatement = @"SELECT Count(*) from `cerealdb`";
var cmd = new MySqlCommand(connStr, conn);
try
{
    using (cmd)
    {
        cmd.ExecuteNonQuery();
        tableExists = true;
    }
}
catch
{
    tableExists = false;
} */

// Opretter en ny tabel til data (cereal)
Console.WriteLine("  Opretter tabel..");
MySqlCommand createTable = new MySqlCommand(@"
    CREATE TABLE `cereal` (
        CerealID INT NOT NULL AUTO_INCREMENT,
        name varchar(255),
        mfr varchar(255),
        type varchar(255),
        calories int,
        protein int,
        fat int,
        sodium int,
        fiber float,
        carbo float,
        sugars int,
        potass int,
        vitamins int,
        shelf int,
        weight float,
        cups float,
        rating float,
        PRIMARY KEY (CerealID)) COLLATE='utf8_general_ci' ENGINE=InnoDB;", conn);
Console.WriteLine("  Tabel oprettet.");
createTable.ExecuteNonQuery();

// Læser CSV filen
Console.WriteLine("  Læser fil...");
using var reader = new StreamReader("data/Cereal.csv");
string? headerLine = reader.ReadLine();

// Så længe der er rækker, indlæs dem 
while (!reader.EndOfStream)
{
    // Læser mellem linjer mellem ";"
    var line = reader.ReadLine();
    if (line == null)
        continue;
    var values = line.Split(';');

    // Navne på rækker i DB og deres værdier
    string name = values[0].Trim();
    string mfr = values[1].Trim();
    string type = values[2].Trim();
    int calories = int.Parse(values[3].Trim(), CultureInfo.InvariantCulture);
    int protein = int.Parse(values[4].Trim(), CultureInfo.InvariantCulture);
    int fat = int.Parse(values[5].Trim(), CultureInfo.InvariantCulture);
    int sodium = int.Parse(values[6].Trim(), CultureInfo.InvariantCulture);
    float fiber = float.Parse(values[7].Trim(), CultureInfo.InvariantCulture);
    float carbo = float.Parse(values[8].Trim(), CultureInfo.InvariantCulture);
    int sugars = int.Parse(values[9].Trim(), CultureInfo.InvariantCulture);
    int potass = int.Parse(values[10].Trim(), CultureInfo.InvariantCulture);
    int vitamins = int.Parse(values[11].Trim(), CultureInfo.InvariantCulture);
    int shelf = int.Parse(values[12].Trim(), CultureInfo.InvariantCulture);
    float weight = float.Parse(values[13].Trim(), CultureInfo.InvariantCulture);
    float cups = float.Parse(values[14].Trim(), CultureInfo.InvariantCulture);

    // Pga. flere "." i rating, så må vi fjerne dem for at de kan indlæses i DB
    string rawRating = values[15].Trim();
    string cleaned = rawRating.Replace(".", "");

    if (!float.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out float rating))
    {
        Console.WriteLine($"Kunne ikke parse rating: {rawRating}");
    }

    // Strengen der indsætter data med værdier
    string sql = @"INSERT INTO cereal
            (name, mfr, type, calories, protein, fat, sodium, fiber, carbo, sugars, potass, vitamins, shelf, weight, cups, rating)
            VALUES 
            (@name, @mfr, @type, @calories, @protein, @fat, @sodium, @fiber, @carbo, @sugars, @potass, @vitamins, @shelf, @weight, @cups, @rating)";

    Console.WriteLine("  Import igang...");
    using var cmd = new MySqlCommand(sql, conn);
    // Tilføjer hvert række med key-value princip
    cmd.Parameters.AddWithValue("@name", name);
    cmd.Parameters.AddWithValue("@mfr", mfr);
    cmd.Parameters.AddWithValue("@type", type);
    cmd.Parameters.AddWithValue("@calories", calories);
    cmd.Parameters.AddWithValue("@protein", protein);
    cmd.Parameters.AddWithValue("@fat", fat);
    cmd.Parameters.AddWithValue("@sodium", sodium);
    cmd.Parameters.AddWithValue("@fiber", fiber);
    cmd.Parameters.AddWithValue("@carbo", carbo);
    cmd.Parameters.AddWithValue("@sugars", sugars);
    cmd.Parameters.AddWithValue("@potass", potass);
    cmd.Parameters.AddWithValue("@vitamins", vitamins);
    cmd.Parameters.AddWithValue("@shelf", shelf);
    cmd.Parameters.AddWithValue("@weight", weight);
    cmd.Parameters.AddWithValue("@cups", cups);
    cmd.Parameters.AddWithValue("@rating", rating);

    cmd.ExecuteNonQuery();

    Console.WriteLine($"   Importeret {name}");

}

Console.WriteLine("~~~~~~ Import Færdig ~~~~~~");