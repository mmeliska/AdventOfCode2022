using Day10;

var fileLines = File.ReadAllLines("input.txt");

// Part 1
InstructionProcessor processor = new InstructionProcessor(20, 40);
processor.RunProgram(fileLines);
Console.WriteLine();
Console.WriteLine("Check Point Sum:" +processor.CheckPointSum);

Console.WriteLine();
Console.WriteLine();

//Part 2
InstructionProcessor processor2 = new InstructionProcessor(40, 40);
processor2.RunProgram(fileLines);