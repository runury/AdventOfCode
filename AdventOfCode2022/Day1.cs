namespace AdventOfCode2022;

public class Day1
{
    private IEnumerable<Elf> input = File.ReadAllText("Input/Day1Input")
        .Split("\n\n")
        .Select(x => new Elf(x.Split("\n")
            .Select(int.Parse)
            .ToList()));

    public Day1()
    {
        var maxCalories = input.MaxBy(x => x.GetTotalCalories).GetTotalCalories;
        Console.WriteLine($"A: The elf carrying the most, carries {maxCalories} calories");

        var topThree = input.Select(x => x.GetTotalCalories).ToList().OrderDescending().Take(3).Sum();
        Console.WriteLine($"B: The three elves carrying the most, carries {topThree} calories");
    }
    
    private class Elf
    {
        public IList<int> Calories { get; }
        public int GetTotalCalories => Calories.Sum();
        
        public Elf(IList<int> calories)
        {
            Calories = calories;
        }
    }
}