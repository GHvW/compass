using System;
using System.IO;

Console.WriteLine("Hello Compass!");

var path = @"C:\Users\ghvw\projects\csharp\compass\shapefile\supercool.shp";

var bytes = await File.ReadAllBytesAsync(path);

Console.WriteLine($"There are {bytes.Length} bytes in the shapefile");
