using Compass;
using Compass.Shapes;
using System;
using System.IO;
using System.Linq;

Console.WriteLine("Hello Compass!");

//var path = @"C:\Users\ghvw\projects\csharp\compass\shapefile\supercool.shp";
var path = @"C:\Users\ghvw\projects\rust\clay\examples\defaultish\defautish.shp";

var bytes = await File.ReadAllBytesAsync(path);

Console.WriteLine($"There are {bytes.Length} bytes in the shapefile");

var (main, rest) = new MainFileHeaderP().Call(bytes).Value;
Console.WriteLine($"main header is {main}");

var polyReader = new PolygonP().AsShapeRecord().ShapefileRecord();

(ShapefileRecord<Polygon>, ArraySegment<byte>)? result;

while (true) { 
    result = polyReader.Call(rest);
    if (result != null) {
        var notNullResult = result.Value;
        Console.WriteLine($"Polygon: {notNullResult.Item1}");
        foreach (var pt in notNullResult.Item1.shapeRecord.Shape.Points) {

            Console.WriteLine($"Polygon Point: {pt}");
        }
        rest = notNullResult.Item2;
    } else {
        break;
    }
} 

