namespace Day2;

public class Outcome
{
    public int Player1Score { get; set; }
    public int Player2Score { get; set; }

    public Outcome(int player1Score, int player2Score)
    {
        Player1Score = player1Score;
        Player2Score = player2Score;
    }
}