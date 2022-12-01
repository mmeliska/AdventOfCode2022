// See https://aka.ms/new-console-template for more information

string content = File.ReadAllText("input.txt");

var elfTotals = content.Split("\n\n")
    .Select(elf => elf.Split('\n')
        .Select(calCount => Int32.Parse(calCount))
        .Sum()
    );

var topElfTotals = elfTotals.OrderByDescending(x => x).Take(3).ToList();

Console.WriteLine("Top Elf: " +topElfTotals.First());
Console.WriteLine("Sum of Top 3 Elves: " +topElfTotals.Sum());