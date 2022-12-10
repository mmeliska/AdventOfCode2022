using Day9;

var fileContents = File.ReadAllLines("input.txt");

// Part 1
Knot head = new Knot();
Knot tail = head.AttachKnot();

// Part 2
var head2 = new Knot();
var tail2 = head2.AttachKnot()
    .AttachKnot()
    .AttachKnot()
    .AttachKnot()
    .AttachKnot()
    .AttachKnot()
    .AttachKnot()
    .AttachKnot()
    .AttachKnot();

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
        head2.Move(direction);
    }
}

Console.WriteLine("Total Tail Positions for Part 1: " +tail.VisitedPoints.Count);
Console.WriteLine("Total Tail Positions for Part 2: " +tail2.VisitedPoints.Count);






