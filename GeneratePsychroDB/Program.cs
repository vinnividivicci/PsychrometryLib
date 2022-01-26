// See https://aka.ms/new-console-template for more information
using PsychrometryLib;
using System.Text;

var csv = new StringBuilder();
var headerLine = $"seriesName, DB, RH, WB, HumidityRatioGrains";
csv.AppendLine(headerLine);

// From 20 F to 120F
var p1 = new PsychrometricPointIP();
//for (int i = 20; i <= 120; i++)
//{
//    // From 1% RH to 100% RH
//    decimal j = (decimal)0.01;
//    while(j <= (decimal)1.0)
//    {
//        p1.CalcAllUsingDbRH(i, j);
//        j += (decimal)0.01;
//        // Console.WriteLine(String.Format("DB: {0}, RH: {1}, Wb: {2}",p1.DryBulbTemperatureInDegF, p1.RelativeHumidityDecimal, p1.WetBulbTemperatureInDegF));
//        var newLine = $"{p1.DryBulbTemperatureInDegF}, {p1.RelativeHumidityDecimal}, {p1.WetBulbTemperatureInDegF}, {p1.HumidityRatioGrainsPerPound}";
//        csv.AppendLine(newLine);
//    } 
//}

// From 1% RH to 100% RH
decimal j = (decimal)0.1;
while (j <= (decimal)1.0)
{
    // From 20 F to 120F
    for (int i = 20; i <= 120; i++)
    {
        p1.CalcAllUsingDbRH(i, j);
        
        // Console.WriteLine(String.Format("DB: {0}, RH: {1}, Wb: {2}",p1.DryBulbTemperatureInDegF, p1.RelativeHumidityDecimal, p1.WetBulbTemperatureInDegF));
        var newLine = $"line_rh_{j}, {p1.DryBulbTemperatureInDegF}, {p1.RelativeHumidityDecimal}, {p1.WetBulbTemperatureInDegF}, {p1.HumidityRatioGrainsPerPound}";
        csv.AppendLine(newLine);
    }
    j += (decimal)0.1;
}

var filePath = "C:\\Users\\vince\\Desktop\\psychroDB.csv";
File.WriteAllText(filePath, csv.ToString());





