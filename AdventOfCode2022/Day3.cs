namespace AdventOfCode2022;

public class Day3
{
    private List<KeyValuePair<string, string>> input1 = 
        File.ReadAllText("Input/Day3Input").Split("\n").ToList()
            .Select(x => new KeyValuePair<string, string>(x.Substring(0, x.Length / 2),  x.Substring(x.Length / 2, x.Length / 2))).ToList();
    
    private List<string> input2 = 
        File.ReadAllText("Input/Day3Input").Split("\n").ToList();

    public Day3()
    {
        string doublePacked = "";
        string triplePacked = "";
        
        foreach (var kvp in input1)
        {
            kvp.Value.ToList().Distinct().Where(x => kvp.Key.Contains(x)).ToList().ForEach(x => doublePacked += x);
        }

        SumOfChars(doublePacked);
        
        for (int i = 0; i < input2.Count; i += 3)
        {
            input2[i].ToList().Distinct()
                .Where(x => input2[i + 1].Contains(x) && input2[i + 2].Contains(x)).ToList().ForEach(x => triplePacked += x);
        }

        SumOfChars(triplePacked);
    }

    private static void SumOfChars(string matches)
    {
        int sum = 0;
        matches.ToList().Where(x => x < 96).ToList().ForEach(x => sum += x - 38);
        matches.ToList().Where(x => x > 96).ToList().ForEach(x => sum += x - 96);
        Console.WriteLine($"Duplicates: {matches}, sum: {sum}");
    }
}