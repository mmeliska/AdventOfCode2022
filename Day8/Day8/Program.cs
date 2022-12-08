// See https://aka.ms/new-console-template for more information

using Day8;

var fileContents = File.ReadAllLines("testInput.txt");

Forest forest = new Forest(fileContents);
ForestSurveyor surveyor = new ForestSurveyor(forest);

Console.WriteLine(forest);
Console.WriteLine("Visible Trees: " +surveyor.CountVisibleTrees());
