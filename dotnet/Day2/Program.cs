using Day2;

string content = File.ReadAllText("input.txt");

string? part = string.Empty;
while (part != "1" && part != "2")
{
    Console.WriteLine("Choose Part (1 or 2)");
    part = Console.ReadLine();
}

var rounds = part == "1" ? Part1Parser.Parse(content) : Part2Parser.Parse(content);
var outcomes = rounds.Select(round => round.Outcome).ToList();

var player1Score = outcomes.Sum(x => x.Player1Score);
var player2Score = outcomes.Sum(x => x.Player2Score);

Console.WriteLine("Player 1 Score:" + player1Score);
Console.WriteLine("Player 2 Score:" + player2Score);