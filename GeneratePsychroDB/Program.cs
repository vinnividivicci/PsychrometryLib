// See https://aka.ms/new-console-template for more information
using PsychrometryLib;
using System.Text;

var csvIP = new StringBuilder();
var headerLineIP = "seriesName, DB, RH, WB, HumidityRatioGrains";
csvIP.AppendLine(headerLineIP);

Console.WriteLine("Generating IP basic series...");
// From 20 F to 120F
var p1 = new PsychrometricPointIP();

// From 1% RH to 100% RH
decimal j = (decimal)0.1;
while (j <= (decimal)1.0)
{
    // From 20 F to 120F
    for (int i = 20; i <= 120; i++)
    {
        p1.CalcAllUsingDbRH(i, j);
        
        var newLine = $"line_rh_{j}, {p1.DryBulbTemperatureInDegF}, {p1.RelativeHumidityDecimal}, {p1.WetBulbTemperatureInDegF}, {p1.HumidityRatioGrainsPerPound}";
        csvIP.AppendLine(newLine);
    }
    j += (decimal)0.1;
}

// SI
var csvSI = new StringBuilder();
var headerLineSI = "seriesName, DB, RH, WB, HumidityRatioGramsPerKilogram";
csvSI.AppendLine(headerLineSI);

Console.WriteLine("Generating SI basic series...");
// From -10 C to 50 C
var p2 = new PsychrometricPointSI();

// From 1% RH to 100% RH
decimal k = (decimal)0.1;
while (k <= (decimal)1.0)
{
    // From -10 C to 50 C
    for (int i = -10; i <= 50; i++)
    {
        p2.CalcAllUsingDbRH(i, k);

        var newLine = $"line_rh_{k}, {p2.DryBulbTemperature}, {p2.RelativeHumidityDecimal}, {p2.WetBulbTemperature}, {p2.HumidityRatioGramsPerKilogram}";
        csvSI.AppendLine(newLine);
    }
    k += (decimal)0.1;
}

Console.WriteLine("Writing files to desktop...");

var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "chartBasicSeriesIP.csv");
File.WriteAllText(filePath, csvIP.ToString());

filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "chartBasicSeriesSI.csv");
File.WriteAllText(filePath, csvSI.ToString());





