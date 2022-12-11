namespace Day8;

public class ForestSurveyor
{
    private readonly Forest _forest;

    public ForestSurveyor(Forest forest)
    {
        _forest = forest;
        ProcessTree();
    }

    private void ProcessTree()
    {
        for (int rowIndex = 0; rowIndex < _forest.RowCount; rowIndex++)
        {
            for (int colIndex = 0; colIndex < _forest.ColumnCount; colIndex++)
            {
                Tree northAndEastTree = _forest.GetTreeAtLocation(rowIndex, colIndex);
                ProcessTreeVisibility(northAndEastTree, Direction.East, Direction.West);
                ProcessTreeVisibility(northAndEastTree, Direction.North, Direction.South);

                Tree westTree = _forest.GetTreeAtLocation(rowIndex, _forest.ColumnCount - colIndex - 1);
                ProcessTreeVisibility(westTree, Direction.West, Direction.East);

                Tree southTree = _forest.GetTreeAtLocation(_forest.RowCount - rowIndex - 1, colIndex);
                ProcessTreeVisibility(southTree, Direction.South, Direction.North);

                CalculateScenicScore(northAndEastTree);
            }
        }
    }

    private void ProcessTreeVisibility(Tree tree, Direction direction, Direction oppositeDirection)
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

    private void CalculateScenicScore(Tree tree)
    {
        tree.ScenicScores[Direction.North] = CalculateScenicScoreForDirection(tree, Direction.North);
        tree.ScenicScores[Direction.East] = CalculateScenicScoreForDirection(tree, Direction.East);
        tree.ScenicScores[Direction.South] = CalculateScenicScoreForDirection(tree, Direction.South);
        tree.ScenicScores[Direction.West] = CalculateScenicScoreForDirection(tree, Direction.West);
    }

    private int CalculateScenicScoreForDirection(Tree tree, Direction direction)
    {
        int counter = 0;
        Tree? neighbor = _forest.GetNeighboringTree(tree, direction);
        while (neighbor != null)
        {
            counter++;
            if (neighbor.Height >= tree.Height)
            {
                break;
            }
            neighbor = _forest.GetNeighboringTree(neighbor, direction);
        }
        
        return counter;
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

    public (int Score, Location Location) FindBestView()
    {
        int max = 0;
        Location location = new Location(-1, -1);
        for (int rowIndex = 0; rowIndex < _forest.RowCount; rowIndex++)
        {
            for (int colIndex = 0; colIndex < _forest.ColumnCount; colIndex++)
            {
                var tree = _forest.GetTreeAtLocation(rowIndex, colIndex);
                var score = tree.OverallScenicScore;
                if (score > max)
                {
                    max = score;
                    location = tree.Location;
                }
            }
        }

        return (max, location);
    }
}