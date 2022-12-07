namespace AdventOfCode2022;

public class Day5
{
    private List<LinkedList<char>> Stacks = new List<LinkedList<char>>() { new (), new (), new (), new (), new (), new (), new (), new (), new (), };
    
    private List<string> input1 = File.ReadAllText("Input/Day5Input1").Split("\n").ToList();
    private List<List<string>> input2 = File.ReadAllText("Input/Day5Input2").Split("\n").ToList().Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();

    public Day5()
    {
        InitializeStacks();

        foreach (var instruction in input2)
            for (int i = 0; i < int.Parse(instruction[1]); i++)
            {
                var blockToMove = Stacks[int.Parse(instruction[3]) - 1].First;
                Stacks[int.Parse(instruction[3]) - 1].Remove(blockToMove);
                Stacks[int.Parse(instruction[5]) - 1].AddFirst(blockToMove);
            }

        var top = string.Concat(Stacks.Select(x => x.First.Value));
        Console.WriteLine($"A: Top items: {top}");
        
        //reset
        Stacks.ForEach(X => X.Clear());
        InitializeStacks();

        foreach (var instruction in input2)
        {
            var blocksToMove = Stacks[int.Parse(instruction[3]) - 1].Take(int.Parse(instruction[1]));
            foreach (var block in blocksToMove.Reverse())
            {
                Stacks[int.Parse(instruction[3]) - 1].Remove(block);
                Stacks[int.Parse(instruction[5]) - 1].AddFirst(block);
            }
        }

        top = string.Concat(Stacks.Select(x => x.First.Value));
        Console.WriteLine($"B: Top items: {top}");
    }

    private void InitializeStacks()
    {
        foreach (var line in input1)
        {
            for (int i = 0; i < line.Length; i += 4)
            {
                if (line.ElementAt(i + 1) != ' ')
                    Stacks[i / 4].AddLast(line.ElementAt(i + 1));
            }
        }
    }
}