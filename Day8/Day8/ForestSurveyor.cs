namespace Day8;

public class ForestSurveyor
{
    private readonly Forest _forest;

    public ForestSurveyor(Forest forest)
    {
        _forest = forest;
        ProcessTreeVisibility();
    }

    private void ProcessTreeVisibility()
    {
        for (int rowIndex = 0; rowIndex < _forest.RowCount; rowIndex++)
        {
            for (int colIndex = 0; colIndex < _forest.ColumnCount; colIndex++)
            {
                Tree northAndEastTree = _forest.GetTreeAtLocation(rowIndex, colIndex);
                ProcessTree(northAndEastTree, Direction.East, Direction.West);
                ProcessTree(northAndEastTree, Direction.North, Direction.South);
                
                Tree westTree = _forest.GetTreeAtLocation(rowIndex, _forest.ColumnCount - colIndex -1);
                ProcessTree(westTree, Direction.West, Direction.East);
                
                Tree southTree = _forest.GetTreeAtLocation(_forest.RowCount - rowIndex - 1, colIndex);
                ProcessTree(southTree, Direction.South, Direction.North);
            }
        }
    }
    
    private void ProcessTree(Tree tree, Direction direction, Direction oppositeDirection)
    {
        var neighborTree = _forest.GetNeighboringTree(tree, direction);
        if (neighborTree != null)
        {
            tree.LineOfSiteHeights[direction] = Math.Max(neighborTree.Height, neighborTree.LineOfSiteHeights[direction].GetValueOrDefault(-1));
            var height = Math.Max(tree.Height, tree.LineOfSiteHeights[direction].GetValueOrDefault(-1));
            var oppositeDirectionTree = _forest.GetNeighboringTree(tree, oppositeDirection);
            while (oppositeDirectionTree != null)
            {
                if (height > (oppositeDirectionTree.LineOfSiteHeights[direction] ?? -1))
                {
                    oppositeDirectionTree.LineOfSiteHeights[direction] = height;
                }

                oppositeDirectionTree = height > tree.Height ? _forest.GetNeighboringTree(oppositeDirectionTree, oppositeDirection) : null;
            }
        }
    }


    public int CountVisibleTrees()
    {
        int counter = 0;
        for (int rowIndex = 0; rowIndex < _forest.RowCount; rowIndex++)
        {
            for (int colIndex = 0; colIndex < _forest.ColumnCount; colIndex++)
            {
                if (_forest.GetTreeAtLocation(rowIndex, colIndex).Visible)
                {
                    counter++;
                }
            }
        }

        return counter;
    }
}