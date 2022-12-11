using System.Data;
using System.Drawing;

namespace Day9;

public class Knot
{
    private Point _position;

    public Point Position
    {
        get => _position;
        set => _position = value;
    }
    
    public HashSet<Point> VisitedPoints = new HashSet<Point>();

    public Knot? AttachedKnot { get; private set; }
    
    public Knot()
    {
        Position = Point.Empty;
        VisitedPoints.Add(_position);
    }
    
    private Knot(Point initialPosition)
    {
        Position = initialPosition;
        VisitedPoints.Add(_position);
    }

    public Knot AttachKnot()
    {
        this.AttachedKnot = new Knot(this.Position);
        return this.AttachedKnot;
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                _position.Offset(0, 1);
                break;
            case Direction.Right:
                _position.Offset(1, 0);
                break;
            case Direction.Down:
                _position.Offset(0, -1);
                break;
            case Direction.Left:
                _position.Offset(-1, 0);
                break;
        };
        VisitedPoints.Add(_position);
        if (this.AttachedKnot != null)
        {
            this.AttachedKnot.FollowPosition(this._position);
        }
    }

    public void FollowPosition(Point other)
    {
        if (!AreTouching(this.Position, other))
        {
            MoveToTouchPoint(other);
            if (this.AttachedKnot != null)
            {
                this.AttachedKnot.FollowPosition(this._position);
            }
        }
    }

    private bool AreTouching(Point point1, Point point2)
    {
        var distance = Math.Sqrt((Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2)));
        return distance < 2;
    }

    private void MoveToTouchPoint( Point point2)
    {
        var angle = Math.Atan(((double)point2.Y - this.Position.Y) / (point2.X - this.Position.X)) * (180/Math.PI);
     
        if (point2.X < this._position.X && angle != 180)
        {
            angle += 180;
        } 
        else if (point2.Y < this._position.Y && point2.X > this._position.X)
        {
            angle += 360;
        }
        
        var offset = angle switch
        {
            0 => new Point(1, 0),
            90 => new Point(0, 1),
            180 => new Point(-1, 0),
            270 or -90 => new Point(0, -1),
            (> 0) and (< 90) => new Point(1, 1),
            (> 90) and (< 180) => new Point(-1, 1),
            (> 180) and (< 270) => new Point(-1, -1),
            (> 270) and (< 360) => new Point(1, -1),
        };
        
        _position.Offset(offset);
        VisitedPoints.Add(_position);
    }
}