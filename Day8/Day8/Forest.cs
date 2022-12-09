using System.Text;

namespace Day8;

public class Forest
{
    private readonly Tree[,] _trees;

    public int RowCount => _trees.GetUpperBound(0) + 1;
    public int ColumnCount => _trees.GetUpperBound(1) + 1;

    public Forest(string[] lines)
    {
        this._trees = ParseForest(lines);
    }

    public Tree GetTreeAtLocation(int row, int col)
    {
        return _trees[row, col];
    }

    public Tree? GetNeighboringTree(Tree tree, Direction direction)
    {
        var nextTree = direction switch
        {
            Direction.North =>
                tree.Location.Row != 0 ? _trees[tree.Location.Row - 1, tree.Location.Column] : null,
            Direction.East => 
                tree.Location.Column != _trees.GetLength(1) - 1 ? _trees[tree.Location.Row, tree.Location.Column + 1] : null,
            Direction.South => 
                tree.Location.Row != _trees.GetLength(0) - 1 ? _trees[tree.Location.Row + 1, tree.Location.Column] : null,
            Direction.West =>
                tree.Location.Column != 0 ? _trees[tree.Location.Row, tree.Location.Column- 1] : null,
            _ => null
        };

        return nextTree;
    }

    private static Tree[,] ParseForest(string[] lines)
    {
        Tree[,] trees = new Tree[lines.Length, lines[0].Length];
        foreach (var (line, rowIndex) in lines.WithIndex())
        {
            foreach (var (treeHeight, colIndex) in line.WithIndex())
            {
                Tree t = new Tree(treeHeight - 48, new Location(rowIndex, colIndex));
                trees[rowIndex, colIndex] = t;
            }
        }

        return trees;
    }
    
    public override string ToString()
    {
        var result = new StringBuilder();
        int uBound0 = _trees.GetUpperBound(0);
        int uBound1 = _trees.GetUpperBound(1);
        for (int i = 0; i <= uBound0; i++)
        {
            for (int j = 0; j <= uBound1; j++) {
                string tree = _trees[i, j].ToString();
                result.Append(tree);
                if (j != uBound1)
                {
                    result.Append(" | ");
                }
            }

            result.Append('\n');
        }

        return result.ToString();
    }
}