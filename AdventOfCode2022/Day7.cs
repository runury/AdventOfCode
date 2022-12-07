namespace AdventOfCode2022;

public class Day7
{
    private List<string> input = File.ReadAllText("Input/Day7Input").Split("\n").ToList();

    private List<Directory> directories = new () { new Directory("/", null) };
    public Day7()
    {
        var topDir = directories.Single();
        var currentDir = topDir;
        
        foreach (var command in input)
        {
            if (command == "$ cd /") { currentDir = topDir;}
            else if (command == "$ cd .." && currentDir != topDir) {  currentDir = currentDir.Parent;}
            else if (command.StartsWith("$ cd "))
            {
                var newDir = currentDir.Children.FirstOrDefault(x => x.Name == command.Split(" ")[2]);
                if (newDir == null)
                {
                    newDir = new Directory(command.Split(" ")[2], currentDir);
                    currentDir.Children.Add(newDir);
                    directories.Add(newDir);
                }
                
                currentDir = newDir;
            }
            else if(command == "$ ls" || command.StartsWith("dir")) { continue; }
            else { currentDir.Files.Add(int.Parse(command.Split(" ")[0])); }
        }

        var smallDirs = directories.Where(x => x.GetSum() < 100000).ToList();
        Console.WriteLine($"A: Combined size of small directories: {smallDirs.Select(x => x.GetSum()).Sum()}");

        var dirs = directories.Where(x => x.GetSum() >= 30000000 - (70000000 - topDir.GetSum())).OrderBy(x => x.GetSum());
        Console.WriteLine($"B: Smallest directory to delete: \'{dirs.First().Name}\', Size: {dirs.First().GetSum()}");
    }
}

public class Directory
{
    public Directory? Parent { get; }
    public List<Directory> Children { get; }
    public List<int> Files { get; }
    public string Name { get; }

    public Directory(string name, Directory parent)
    {
        Name = name;
        Parent = parent;
        Children = new List<Directory>();
        Files = new List<int>();
    }

    public int GetSum() => Files.Sum() + Children.Select(x => x.GetSum()).Sum();
}