using Day8;

var fileContents = File.ReadAllLines("input.txt");

Forest forest = new Forest(fileContents);
ForestSurveyor surveyor = new ForestSurveyor(forest);

Console.WriteLine(forest);
Console.WriteLine("Visible Trees: " +surveyor.CountVisibleTrees());

var bestView = surveyor.FindBestView();
Console.WriteLine("Best Scenic Score: " +bestView.Score +" " +bestView.Location);

