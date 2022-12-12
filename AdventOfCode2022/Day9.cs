using System.Drawing;

namespace AdventOfCode2022;

public class Day9
{
    private List<string> input = File.ReadAllText("Input/Day9Input").Split("\n").ToList();
    public List<Point> Moves = new () { new Point() };
    
    public Day9()
    {
        var oneLinkRope = new List<Point> { new () };
        var currentHead = Point.Empty;
        MoveRope(currentHead, oneLinkRope);
        
        Console.WriteLine($"A: Moves: {Moves.Count}");
        
        var nineLinkRope = new List<Point> { new (), new (), new (), new (), new (), new (), new (), new (), new () };
        currentHead = Point.Empty;
        Moves = new () { new Point() };
        
        MoveRope(currentHead, nineLinkRope);
        
        Console.WriteLine($"B: Moves: {Moves.Count}");
    }

    private void MoveRope(Point currentHead, List<Point> rope)
    {
        input.ForEach(instruction =>
        {
            var noOfMoves = int.Parse(instruction.Split(" ")[1]);
            for (int i = 0; i < noOfMoves; i++)
            {
                var direction = instruction.Split(" ")[0];
                switch (direction)
                {
                    case "U": currentHead.Y++; break;
                    case "D": currentHead.Y--; break;
                    case "R": currentHead.X++; break;
                    case "L": currentHead.X--; break;
                }
                
                var previousKnot = currentHead;

                for (int j = 0; j < rope.Count; j++)
                {
                    rope[j] = Move(rope[j], previousKnot, j == rope.Count - 1);
                    previousKnot = rope[j];
                }
            }
        });
    }

    public Point Move(Point knotToMove, Point previousKnot, bool addToMoves)
    {
        if (previousKnot.Y - knotToMove.Y > 1) { knotToMove.Y++; CatchUpX(); }
        if (knotToMove.Y - previousKnot.Y > 1) { knotToMove.Y--; CatchUpX(); }
        if (previousKnot.X - knotToMove.X > 1) { knotToMove.X++; CatchUpY(); }
        if (knotToMove.X - previousKnot.X > 1) { knotToMove.X--; CatchUpY(); }
                
        AddMove(knotToMove);
        
        return knotToMove;

        void AddMove(Point point)
        {
            if(addToMoves && !Moves.Any(p => p.X == point.X && p.Y == point.Y))
                Moves.Add(point);
        }

        void CatchUpX()
        {
            if (knotToMove.X != previousKnot.X)
            {
                var _ = knotToMove.X < previousKnot.X ? knotToMove.X++ : knotToMove.X--;
            }
        }
        
        void CatchUpY()
        {
            if (knotToMove.Y != previousKnot.Y)
            {
                var _ = knotToMove.Y < previousKnot.Y ? knotToMove.Y++ : knotToMove.Y--;
            }
        }
    }
}