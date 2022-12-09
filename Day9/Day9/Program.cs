using System.Drawing;
using Day9;

var fileContents = File.ReadAllLines("input.txt");

Knot head = new Knot();
Knot tail = new Knot();
HashSet<Point> visitedPoints = new HashSet<Point>();

foreach(var line in fileContents)
{
    string[] parts = line.Split(' ');
    var direction = parts[0] switch
    {
        "U" => Direction.Up,
        "R" => Direction.Right,
        "D" => Direction.Down,
        "L" => Direction.Left,
        _ => throw new ArgumentOutOfRangeException()
    };

    var count = Int32.Parse(parts[1]);

    for (int i = 0; i < count; i++)
    {
        head.Move(direction);
        tail.FollowPosition(head.Position);
        visitedPoints.Add(tail.Position);
        Console.WriteLine($"H:{head.Position}, T:{tail.Position}");
    }
}

Console.WriteLine("Total Tail Positions: " +visitedPoints.Count);


