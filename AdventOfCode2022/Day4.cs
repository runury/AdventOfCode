namespace AdventOfCode2022;

public class Day4
{
    private List<Ranges> input = File.ReadAllText("Input/Day4Input").Split("\n").Select(x => new Ranges(x.Split(','))).ToList();

    public Day4()
    {
        var CoveredinRange = input.Count(x => x.CompletelyCovered());
        Console.WriteLine($"A: CompletelyCovered: {CoveredinRange}");
        
        var overlaps = input.Count(x => x.Overlaps());
        Console.WriteLine($"B: Overlaps: {overlaps}");
    }
}

class Ranges
{
    public int[] Elf1;
    public int[] Elf2;
    public Ranges(string[] ranges)
    {
        var a = ranges[0].Split('-').Select(int.Parse).ToArray();
        var b = ranges[1].Split('-').Select(int.Parse).ToArray();

        if (a[0] <= b[0])
        {
            Elf1 = a;
            Elf2 = b;
        }
        else
        {
            Elf1 = b;
            Elf2 = a;
        }
    }

    public bool CompletelyCovered() => Elf1[1] >= Elf2[1] || (Elf1[0] == Elf2[0] && Elf2[1] >= Elf1[1]);
    public bool Overlaps() => Elf2[0] <= Elf1[1];
    
}