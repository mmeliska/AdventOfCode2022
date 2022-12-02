namespace Day2;

public class Part2Parser
{
    public static List<Round> Parse(string content)
    {
        var rounds = content
            .Split('\n')
            .Select(line =>
            {
                var player1Throw = ParseThrow(line[0]);
                var player2Throw = ParseFixedThrow(line[2], player1Throw);
                return new Round(player1Throw, player2Throw);
            }
        );

        return rounds.ToList();
    }

    private static ThrowType ParseThrow(char letter)
    {
        return letter switch
        {
            'A' => ThrowType.Rock,
            'B' => ThrowType.Paper,
            'C' => ThrowType.Scissors,
            _ => throw new ArgumentException("Invalid Input")
        };
    }

    private static ThrowType ParseFixedThrow(char letter, ThrowType opponentThrow)
    {
        return letter switch
        {
            'X' => (ThrowType)(((int)opponentThrow + 1) % 3) + 1,
            'Y' => opponentThrow,
            'Z' => (ThrowType)((int)opponentThrow % 3) + 1,
            _ => throw new ArgumentException("Invalid Input")
        };
    }
}