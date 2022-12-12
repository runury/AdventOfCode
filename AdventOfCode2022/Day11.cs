using System.Data.Common;
using System.Threading.Channels;

namespace AdventOfCode2022;

public class Day11
{
    static List<Monkey> monkeys;

    private void populateMonkeys()
    {
        monkeys = new()
        {
            new Monkey(new List<long>{99, 67, 92, 61, 83, 64, 98},     x => x * 17, x => x % 3 == 0,  4, 2),
            new Monkey(new List<long>{78, 74, 88, 89, 50},             x => x * 11, x => x % 5 == 0,  3, 5),
            new Monkey(new List<long>{98, 91},                         x => x + 4,  x => x % 2 == 0,  6, 4),
            new Monkey(new List<long>{59, 72, 94, 91, 79, 88, 94, 51}, x => x * x,  x => x % 13 == 0, 0, 5),
            new Monkey(new List<long>{95, 72, 78},                     x => x + 7,  x => x % 11 == 0, 7, 6),
            new Monkey(new List<long>{76},                             x => x + 8,  x => x % 17 == 0, 0, 2),
            new Monkey(new List<long>{69, 60, 53, 89, 71, 88},         x => x + 5,  x => x % 19 == 0, 7, 1),
            new Monkey(new List<long>{72, 54, 63, 80},                 x => x + 3,  x => x % 7 == 0,  1, 3)
        };
    }
    public Day11()
    {
        populateMonkeys();
        for (int i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                while(monkey.Items.Any())
                {
                    monkey.Inspect();
                    monkey.CalmDownA();
                    monkey.Test();
                }
            }
        }
        
        var topMonkeys = monkeys.OrderByDescending(x => x.NumberOfInspections).Take(2);
        Console.WriteLine($"A: Monkey business for top two monkeys {topMonkeys.First().NumberOfInspections * topMonkeys.Last().NumberOfInspections}");
        
        //Part Two
        populateMonkeys();
        for (int i = 0; i < 10000; i++)
        {
            foreach (var monkey in monkeys)
            {
                while(monkey.Items.Any())
                {
                    monkey.Inspect();
                    monkey.CalmDownB();
                    monkey.Test();
                }
            }
        }

        topMonkeys = monkeys.OrderByDescending(x => x.NumberOfInspections).Take(2);
        Console.WriteLine($"B: Monkey business for top two monkeys {topMonkeys.First().NumberOfInspections * topMonkeys.Last().NumberOfInspections}");
    }
    
    class Monkey
    {
        public long NumberOfInspections;
        public List<long> Items;
        public Func<long, long> InspectFunc;
        public Func<long, bool> TestFunc;

        public int ReceiverOnFalse;
        public int ReceiverOnTrue;

        public void Inspect()
        {
            NumberOfInspections++;
            Items[0] = InspectFunc.Invoke(Items[0]);
        }

        //2*3*5*7*11*13*17*19 = common prime denominator
        public void CalmDownB() => Items[0] %=9699690;
        public void CalmDownA() => Items[0] /= 3;
        public void Test()
        {
            var receiver = TestFunc.Invoke(Items[0]) ? ReceiverOnTrue : ReceiverOnFalse;
            monkeys[receiver].Items.Add(Items[0]);
            Items.RemoveAt(0);
        }

        public Monkey(List<long> items, Func<long, long> inspectFunc, Func<long, bool> testFunc, int receiverOnTrue, int receiverOnFalse)
        {
            Items = items;
            InspectFunc = inspectFunc;
            TestFunc = testFunc;
            ReceiverOnFalse = receiverOnFalse;
            ReceiverOnTrue = receiverOnTrue;
        }
    }
}