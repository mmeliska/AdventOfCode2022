namespace Day10;

public class InstructionProcessor
{
    private int _checkpointStart { get; set; }
    private int _checkpointIncrement { get; set; }
    
    private int _registerX = 1;
    private int _checkPoint = 20;
    private int _cycle = 1;
    public int CheckPointSum { get; set; }


    public InstructionProcessor(int checkpointStart, int checkpointIncrement)
    {
        _checkpointStart = checkpointStart;
        _checkpointIncrement = checkpointIncrement;
    }

    public void RunProgram(string[] instructions)
    {
        Reset();
        foreach (var (line, index) in instructions.WithIndex())
        {
            if (line.StartsWith("addx"))
            {
                var parts = line.Split(' ');
                var number = Int32.Parse(parts[1]);
                PrintPixel();
                IncreaseCycle();
                PrintPixel();
                IncreaseCycle();
                _registerX += number;
            }
            else
            {
                PrintPixel();
                IncreaseCycle();
            }
        }
    }

    private void Reset()
    {
        _registerX = 1;
        _cycle = 1;
        _checkPoint = _checkpointStart;
    }

    private void IncreaseCycle()
    {
        if (_cycle == _checkPoint)
        {
            CheckPointSum += _registerX * _checkPoint;
            _checkPoint += _checkpointIncrement;
        }
        _cycle++;
    }

    private void PrintPixel()
    {
        var position = (_cycle -1) % (_checkpointIncrement);
        if (position >= _registerX - 1 && position <= _registerX + 1)
        {
            Console.Write("#");
        }
        else
        {
            Console.Write(".");
        }

        if (position == _checkpointIncrement - 1)
        {
            Console.Write("\n");
        }
    }
}