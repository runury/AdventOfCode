namespace AdventOfCode2021;

public class Day6
{
    private List<int> input = ("1,1,3,5,3,1,1,4,1,1,5,2,4,3,1,1,3,1,1,5,5,1,3,2,5,4,1,1,5,1,4,2,1,4,2,1,4,4,1,5,1,4,4,1,1,5,1,5,1,5,1,1,1,5,1,2,5,1,1,3,2,2,2,1,4,1,1,2,4,1,3,1,2,1,3,5,2,3,5,1,1,4,3,3,5,1,5,3,1,2,3,4,1,1,5,4,1,3,4,4,1,2,4,4,1,1,3,5,3,1,2,2,5,1,4,1,3,3,3,3,1,1,2,1,5,3,4,5,1,5,2,5,3,2,1,4,2,1,1,1,4,1,2,1,2,2,4,5,5,5,4,1,4,1,4,2,3,2,3,1,1,2,3,1,1,1,5,2,2,5,3,1,4,1,2,1,1,5,3,1,4,5,1,4,2,1,1,5,1,5,4,1,5,5,2,3,1,3,5,1,1,1,1,3,1,1,4,1,5,2,1,1,3,5,1,1,4,2,1,2,5,2,5,1,1,1,2,3,5,5,1,4,3,2,2,3,2,1,1,4,1,3,5,2,3,1,1,5,1,3,5,1,1,5,5,3,1,3,3,1,2,3,1,5,1,3,2,1,3,1,1,2,3,5,3,5,5,4,3,1,5,1,1,2,3,2,2,1,1,2,1,4,1,2,3,3,3,1,3,5").Split(',').Select(int.Parse).ToList();

    public Day6()
    {
        var counters = new long[]
        {
            input.Count(x => x == 0),
            input.Count(x => x == 1),
            input.Count(x => x == 2),
            input.Count(x => x == 3),
            input.Count(x => x == 4),
            input.Count(x => x == 5),
            input.Count(x => x == 6),
            input.Count(x => x == 7),
            input.Count(x => x == 8),
        };

        long tempValue = 0;
        for (int i = 1; i <= 256; i++)
        {
            tempValue = counters[0];
            
            counters[0] = counters[1];
            counters[1] = counters[2];
            counters[2] = counters[3];
            counters[3] = counters[4];
            counters[4] = counters[5];
            counters[5] = counters[6];
            counters[6] = counters[7];
            counters[7] = counters[8];
            counters[8] = tempValue;

            counters[6] += tempValue;
            
            Console.WriteLine($"A: after {i} days, {counters.ToList().Sum()} fish exists");
        }
    }
}