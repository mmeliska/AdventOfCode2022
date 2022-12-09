namespace Day8;

public class Tree
{
    public int Height { get; set; }
    public Location Location { get; set; }
    
    public readonly Dictionary<Direction, int?> LineOfSiteHeights = new();
    
    public readonly Dictionary<Direction, int?> ScenicScores = new();

    public int OverallScenicScore => ScenicScores.Select(x => x.Value.GetValueOrDefault(0)).Aggregate((a, b) => a * b);

    public bool Visible => LineOfSiteHeights.Any(x => (x.Value ?? -1) < Height);

    public Tree(int height, Location location)
    {
        this.Height = height;
        Location = location;
        LineOfSiteHeights.Add(Direction.North, null);
        LineOfSiteHeights.Add(Direction.East, null);
        LineOfSiteHeights.Add(Direction.South, null);
        LineOfSiteHeights.Add(Direction.West, null);
        ScenicScores.Add(Direction.North, null);
        ScenicScores.Add(Direction.East, null);
        ScenicScores.Add(Direction.South, null);
        ScenicScores.Add(Direction.West, null);
    }

    public override string ToString()
    {
        string GetLineOfSightHeight(Direction direction) => LineOfSiteHeights[direction]?.ToString() ?? "_";
        string GetScenicScore(Direction direction) => ScenicScores[direction]?.ToString() ?? "_";
        var result =
            $"{Height} - ({GetLineOfSightHeight(Direction.North)}, {GetLineOfSightHeight(Direction.East)}, {GetLineOfSightHeight(Direction.South)}, {GetLineOfSightHeight(Direction.West)})";
        result +=
            $" | S: {OverallScenicScore} - ({GetScenicScore(Direction.North)}, {GetScenicScore(Direction.East)}, {GetScenicScore(Direction.South)}, {GetScenicScore(Direction.West)})";
        return result;
    }
}