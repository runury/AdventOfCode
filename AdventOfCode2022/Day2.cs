namespace AdventOfCode2022;

public class Day2
{
    private List<rpsRound> input1 = File.ReadAllText("Input/Day2Input").Split("\n").Select(x => new rpsRound(x.Split(" "), false)).ToList();
    private List<rpsRound> input2 = File.ReadAllText("Input/Day2Input").Split("\n").Select(x => new rpsRound(x.Split(" "), true)).ToList();

    public Day2()
    {
        var totalScore = input1.Select(x => x.GetScore()).Sum();
        Console.WriteLine($"A: total score: {totalScore}");
        
        var totalScoreB = input2.Select(x => x.GetScore()).Sum();
        Console.WriteLine($"B: total score: {totalScoreB}");
    }
}

class rpsRound
{
    public RPS Elf { get; }
    public RPS Me { get; }

    public int GetScore()
    {
        if (Elf == Me) return 3 + (int)Me;
        if (Elf == RPS.Rock && Me == RPS.Scissors) return 3;
        if (Me == RPS.Rock && Elf == RPS.Scissors) return 7;
        return Elf > Me ? (int)Me : 6 + (int)Me;
    }
    
    public rpsRound(string[] letters, bool part2)
    {
            
        Elf = letters[0] == "A" ? RPS.Rock : letters[0] == "B" ? RPS.Paper : RPS.Scissors;
            
        if(!part2)
            Me = letters[1] == "X" ? RPS.Rock : letters[1] == "Y" ? RPS.Paper : RPS.Scissors;
        else
            Me = letters[1] == "X" ? Elf.Previous() :
                    letters[1] == "Y" ? Elf : Elf.Next();
    }
}

public static class Extentions
{
    public static RPS Previous(this RPS current) => current switch { RPS.Paper => RPS.Rock, RPS.Scissors => RPS.Paper, _ => RPS.Scissors };
    public static RPS Next(this RPS current) => (RPS)((int)current % Enum.GetValues<RPS>().Length + 1);
}

public enum RPS { Rock = 1, Paper = 2, Scissors = 3}