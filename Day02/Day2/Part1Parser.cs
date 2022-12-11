namespace Day2;

public class Part1Parser
{
    public static List<Round> Parse(string content)
    {
        var rounds = content.Split('\n').Select(line =>
            new Round(ParseThrow(line[0]), ParseThrow(line[2]))
        );

        return rounds.ToList();
    }

    private static ThrowType ParseThrow(char letter)
    {
        return letter switch
        {
            'A' or 'X' => ThrowType.Rock,
            'B' or 'Y' => ThrowType.Paper,
            'C' or 'Z' => ThrowType.Scissors,
            _ => throw new ArgumentException("Invalid Input")
        };
    }
}