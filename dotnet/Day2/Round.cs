using System.Diagnostics;

namespace Day2;

public class Round
{
    public int Player1Throw { get; private set; }
    public  int Player2Throw { get; private set; }

    public Outcome Outcome => this switch
    {
        var rnd when rnd.Player1Throw == rnd.Player2Throw => new Outcome(rnd.Player1Throw + 3, rnd.Player2Throw + 3),
        var rnd when rnd.Player1Throw - 1 == rnd.Player2Throw % 3 => new Outcome(rnd.Player1Throw + 6, rnd.Player2Throw ),
        _ => new Outcome(Player1Throw, Player2Throw + 6)

    };

    public Round(ThrowType player1Throw, ThrowType player2Throw)
    {
        Player1Throw = (int)player1Throw;
        Player2Throw = (int)player2Throw;
    }
}