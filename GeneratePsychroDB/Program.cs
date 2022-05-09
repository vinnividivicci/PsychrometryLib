// See https://aka.ms/new-console-template for more information
using PsychrometryLib;
using System.Text;

var csvIP = new StringBuilder();
var headerLineIP = $"units, seriesName, DB, RH, WB, HumidityRatioGrains";
csvIP.AppendLine(headerLineIP);

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
var headerLineSI = $"seriesName, DB, RH, WB, HumidityRatioGramsPerKilogram";
csvIP.AppendLine(headerLineSI);

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
    j += (decimal)0.1;
}

// var filePath = "C:\\Users\\vince\\Desktop\\psychroDB.csv";
var filePath = "C:\\Users\\vince\\Desktop\\psychroDB_IP.csv";
File.WriteAllText(filePath, csvIP.ToString());

filePath = "C:\\Users\\vince\\Desktop\\psychroDB_SI.csv";
File.WriteAllText(filePath, csvSI.ToString());





