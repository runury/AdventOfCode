namespace AdventOfCode2022;

public class Day8
{
    private int[][] input = File.ReadAllText("Input/Day8Input").Split("\n").ToList().Select(x=> x.ToArray().Select(y => int.Parse(y.ToString())).ToArray()).ToArray();

    public Day8()
    {
        Console.WriteLine($"A: Visible trees: {FindVisibleTrees()}");
        Console.WriteLine($"8: Maximum visible trees: {FindHighestScenicScore()}");
    }

    private int FindHighestScenicScore()
    {
        var highscore = 0;
        
        for (int row = 0; row < input.Length; row++)
        {
            for (int col = 0; col < input.Length; col++)
            {
                List<int> scenicScore = new List<int>();

                if (!(row == 0 || row == input.Length - 1 || col == 0 || col == input.Length - 1))
                {
                    scenicScore.Add(GetVisibleTrees(input[row][..col].Reverse(), input[row][col]));
                    scenicScore.Add(GetVisibleTrees(input[row][(col + 1)..], input[row][col]));
                    scenicScore.Add(GetVisibleTrees(input[..(row)].Reverse().Select(x => x[col]), input[row][col]));
                    scenicScore.Add(GetVisibleTrees(input[(row + 1)..].Select(x => x[col]), input[row][col]));
                    
                    highscore = int.Max(highscore, scenicScore.Aggregate((a, b) => a * b));
                }
            }
        }
        
        return highscore;

        int GetVisibleTrees(IEnumerable<int> LinesOfTrees, int currentHeight)
        {
            if (!LinesOfTrees.Any()) return 0;
            
            var result = 1;

            if (LinesOfTrees.First() < currentHeight)
                result = 1 + GetVisibleTrees(LinesOfTrees.Skip(1), currentHeight);
            
            return result;
        }
    }

    private int FindVisibleTrees()
    {
        var sum = new List<int>();
        
        for (int row = 0; row < input.Length; row++)
        {
            for (int col = 0; col < input.Length; col++)
            {
                if (row == 0 || row == input.Length - 1 || col == 0 || col == input.Length - 1)
                {
                    sum.Add(input[row][col]);
                }
                else if (input[row][..col].Max() < input[row][col] ||
                         input[row][(col + 1)..].Max() < input[row][col] ||
                         input[..(row)].ToList().Select(x => x[col]).Max() < input[row][col] ||
                         input[(row + 1)..].Select(x => x[col]).Max() < input[row][col])
                {
                    sum.Add(input[row][col]);
                }
            }
        }

        return sum.Count;
    }
}