namespace Day8;

public class Location
{
    public int Row { get; set; }

    public int Column { get; set; }
    
    
    public Location(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public override string ToString()
    {
        return $"[{Row},{Column}]";
    }
}