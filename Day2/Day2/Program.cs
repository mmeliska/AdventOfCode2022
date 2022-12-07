using Day2;

string content = File.ReadAllText("input.txt");

var rounds = Part1Parser.Parse(content);
var outcomes = rounds.Select(round => round.Outcome).ToList();

var player1Score = outcomes.Sum(x => x.Player1Score);
var player2Score = outcomes.Sum(x => x.Player2Score);

Console.WriteLine("Part 1");
Console.WriteLine("Player 1 Score:" + player1Score);
Console.WriteLine("Player 2 Score:" + player2Score);
Console.WriteLine("");


rounds = Part2Parser.Parse(content);
outcomes = rounds.Select(round => round.Outcome).ToList();

player1Score = outcomes.Sum(x => x.Player1Score);
player2Score = outcomes.Sum(x => x.Player2Score);

Console.WriteLine("Part 2");
Console.WriteLine("Player 1 Score:" + player1Score);
Console.WriteLine("Player 2 Score:" + player2Score);