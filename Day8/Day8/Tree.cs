using System.Drawing;

namespace Day8;

public class Tree
{
    public int Height { get; set; }
    public Location Location { get; set; }


    public Dictionary<Direction, int?> LineOfSiteHeights = new();

    public bool Visible => LineOfSiteHeights.Any(x => (x.Value ?? -1) < Height);

    public Tree(int height, Location location)
    {
        this.Height = height;
        Location = location;
        LineOfSiteHeights.Add(Direction.North, null);
        LineOfSiteHeights.Add(Direction.East, null);
        LineOfSiteHeights.Add(Direction.South, null);
        LineOfSiteHeights.Add(Direction.West, null);
    }

    public override string ToString()
    {
        string GetLineOfSightHeight(Direction direction) => LineOfSiteHeights[direction]?.ToString() ?? "_";
        var result = $"{Height} - ({GetLineOfSightHeight(Direction.North)}, {GetLineOfSightHeight(Direction.East)}, {GetLineOfSightHeight(Direction.South)}, {GetLineOfSightHeight(Direction.West)})";

        return result;
    }
}