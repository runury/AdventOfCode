namespace AdventOfCode2022;

public class Day6
{
    private string input = File.ReadAllText("Input/Day6Input");

    public Day6()
    {   
        Console.WriteLine($"B: {FindUniqueSubstringEnd(4, input)}");
        Console.WriteLine($"B: {FindUniqueSubstringEnd(14, input)}");
    }

    private int FindUniqueSubstringEnd(int substringLength, string stringToSearch)
    {
        for (int i = 0; i < stringToSearch.Length; i++)
        {
            if (stringToSearch.Substring(i, substringLength).Distinct().Count() == substringLength)
                return i + substringLength;
        }

        return -1;
    }
}