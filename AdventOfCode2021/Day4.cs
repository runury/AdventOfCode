namespace AdventOfCode2021;

public class Day4
{
    private string[] drawNumbers = ("68,30,65,69,5,78,41,73,55,0,76,98,79,42,37,21,9,34,56,33,64,54,24,43,15,58,61,38,12,20,4,26,87,95,94,89,83,74,97,77,67,40,63,88,19,31,81,80,60,14,18,47,93,57,17,90,84,85,48,6,91,7,86,13,51,53,8,16,23,66,36,39,32,82,72,11,52,28,62,70,59,50,1,46,96,71,35,10,25,22,27,99,29,45,44,3,75,92,49,2").Split(',');
    private static string[] boardNumbers = ("68 16 83 90 69\n14 89 72 33  6\n63 21 43 64 76\n79 65 87 98 85\n41 24 32 53 93\n\n15 94 72 30  6\n14 80 66  4 78\n44 81 68 67 96\n65 21 64 97 35\n84 90 28 60  2\n\n97 39 61 15 94\n75 14 66 98 31\n58 80  9 64 56\n19 42 16 85 37\n25 22 38 65 82\n\n86 31 71 11 56\n99 12 17 10 46\n 5 33 85 61  2\n30  1 28 88 66\n15 38 21 54 64\n\n38 52 84 75 91\n77  5 49 71 31\n45  1 60  0 10\n68 29 98 36 34\n61 90 93 14 12\n\n91 66 28 41 78\n89 16 10 77 39\n84 57 44 32 47\n60 62 26 21 50\n75 61 24 54 93\n\n 2 69 99  8 20\n14 35 61 85 73\n39 94 37 63 12\n57 23 30 50 17\n34 70 19 28 77\n\n50 82 41 59 52\n43 76 85 63 48\n56 67 60 33 45\n42  9 91 23 16\n96  6 34 30 44\n\n 0 41 24 42 83\n17  1 34 29 71\n46 67 86 64 21\n95 36  6 38 62\n93  8 30 77 44\n\n 6 94 11 14 83\n65 85 97 37 55\n56 19 91 69  1\n26 59 13 96 68\n 4 28  7 45 53\n\n96 78  2 32 65\n 3 63 74 17  4\n76 11 91 48 70\n71 55 69 13 49\n88 30 23 59 10\n\n28  4 34 64 47\n99 86 44 59 43\n50 91 35 92 51\n32 21 19 74 33\n10 29 66 52 94\n\n 0 27 12 23 71\n54 59 32 47 45\n22 85 94 34 31\n29 68 44 61 62\n96 46 52 33 69\n\n37 79 34 17 56\n26 62  3 77 80\n88 35 71 87 36\n89 60 86 19 48\n82 97 95 85  0\n\n62 49 48 98 10\n89 37 50 64 17\n80  5 26 42 51\n58 74  6 20 14\n72  2  9 40 69\n\n71 37 47 21 39\n36 29 26 82 53\n10 17 96 15 43\n 8 92 19  6 32\n77 89 38 54 13\n\n16 58 67 23 98\n43 42 26 46 13\n32 22 27 20 21\n37 33 55 86  1\n99 40 17 44 94\n\n81 59 53 27 36\n11 88 92 57 44\n 2 26 93 94 77\n76 47 82 19 75\n99 34 98 37 32\n\n28 13 57 99  7\n42 93 10 76 43\n 1 52  3 20 53\n82 81 51  2 92\n94 35 49 37  0\n\n 5 30 61 77 44\n82 67 98  1 90\n18 62 27 24 15\n16 20 71 69 19\n85 96 25  7 55\n\n39 51  4 32 30\n64 22 29 48 60\n78 31 44 59 92\n65 10 68 84 16\n40 70 35 26 56\n\n54 83 12 79 66\n21 49 70  2 24\n20 51 71 99 50\n82 36 57 96 22\n78 52 67 33 72\n\n 3 62  5 14 63\n54 75 28 22 51\n 1 55 86 30 70\n 9  6 92 83 85\n71 78 96 47 17\n\n71 59 38 27  2\n90  6 97 75 84\n29 69 45 11 65\n46 31 79  4  8\n51 76 74 87 19\n\n83 67 10 39 57\n 7 63 12 59  2\n54 99 95 88 40\n38 71 84 61 56\n81 90 36 58 19\n\n 4 47 21 28 46\n22 40 94 83 86\n82 17 43  0 45\n55 36 68 35 84\n52 24  6 80  2\n\n29 16 75 26 87\n 6 82 67 36 24\n13 95 35 43 40\n80 68  0 79 71\n34 44 21 30 85\n\n91 25 24 15 23\n93 14 50 75 74\n88 30 64 52  8\n 1  7  0  4 80\n96 82 98 81 67\n\n52 21 71 78  4\n45 73 27 30 56\n 7 93 67  6  1\n54 20 57 69  2\n94 36 89 46 68\n\n86 95 15  7 18\n 8 87 29 11 74\n71 72 43 76 40\n 6 60 44 19 99\n97 85  5 39 77\n\n49 14  5 48 33\n95 21 30  1 47\n87 84 85 10 24\n32 86 99 31 23\n69  2 43 37 60\n\n57 48 99 49 73\n31 92 76 60 96\n47 28 15 70 26\n68 19 56 67 95\n12 23 45 88  6\n\n77 49 23 42 62\n47  7 80 43  4\n59 72 87 14 84\n66 81 96 97 78\n61 91  8 17 48\n\n21 25  1 82 20\n78 31 15 30 73\n46 11 13 35 79\n60 22 97 32  4\n23 88 63 17 75\n\n 6  3 41  5 44\n91 21 32 49 81\n29 85 47 20 14\n99 31 43 22 69\n90  4 45  8 16\n\n12 15 96  3 21\n38 71 16 39 24\n77 82 57 55 92\n27 17 19 73 31\n74 48 34 72 14\n\n80 16 10 79 55\n93 60  4  0 29\n 7 97  3  9 86\n43 67 78 64 35\n44 83 40 33 12\n\n36 88 22 21 70\n30 60 13  6 41\n71 89 86 17 39\n73  0 75 32  9\n 5 10 83 85 99\n\n40 41 76 38 25\n21 49 79 47 39\n27 88 34 81 24\n69 64 36 32  4\n57  5 58 67 56\n\n25 95 41 27 19\n93  0 29 56  8\n 2 17 66 11 82\n96 55 44 39  5\n67  4 33 62 40\n\n85 12 46 59 36\n91 29 19 63  0\n72 49 14  6 95\n18 50 60 67 80\n10 62 39 82 58\n\n11 87  4 76 75\n64 47 26 74 98\n89 30 68 21 88\n45 41 77 67 53\n96 92 44  1 18\n\n33 26 21  8 76\n15 27 41 43 52\n64 85 56 57 66\n11 73 62 69  4\n36 13 94 86 55\n\n93 80 67 23  6\n57 20 29 69  1\n76 96 72 95 33\n32 91 52 16 83\n26 54 13 94 47\n\n56  0 58 15 45\n91 40 86 61 60\n14 47 30  5 24\n21 12 33 69 41\n78 98  9 99 46\n\n59  1 63 96 14\n15 56 23 85 84\n29 98 44 87 46\n75  8 21 54 65\n80 30 40 45  6\n\n99 40 87  4 63\n64 78 50 74 58\n37 47 61 48 59\n65 56 45 89 67\n18 70 71 90 32\n\n42 35  1  9 90\n89 13  0 88 17\n67 82 31 77 91\n60 29 68 10 64\n20 92 46 71 95\n\n 0 32 81 13 63\n87 17  2 56 69\n23 33 29 67 24\n98 95 86 36 31\n99 42 35 93  1\n\n71 79 38 84 29\n26 31 73  1 48\n94 85  3 82 89\n19 17 98 92 47\n96 45 11 70 51\n\n14 69 61 56 33\n98 88 82 76 66\n87 92 42 99 35\n 0 68  6 44 47\n 4 91 54 62 23\n\n10 23 20 40 96\n33  0 21 94 25\n 4 67 30 88 54\n43 41 60  1 82\n18 78 74 98 91\n\n60 95 53  7 11\n67 54 44 18  0\n89 98 24 55 37\n39  5 27 62 21\n75 25 43 47 71\n\n 5 95 60 19  3\n13 15 42 97 67\n61 79  7 12 39\n53 58 89 25 34\n 9 11 96 21 66\n\n89 97 45 84 67\n37 22 64 39 95\n68 63  6 90 80\n92 26 33 35 19\n29 70  5 72 31\n\n52 46 53  6 31\n77  8 59 99 49\n11 48  4 90 91\n41 70 58 16 44\n 7 61  9 80 50\n\n75  0 38 37 33\n99 66 98 14 62\n46 51 43 34 24\n71 92 80 32 22\n60 39 17 52 45\n\n92 49 80 99 16\n 6 77 65  9  4\n34 91 86 43 21\n 0  3 27 84 81\n28  5 19 95 76\n\n 5 40 26 89  1\n51 30 75 46 31\n35 58 86 80  0\n98 38 27 81 93\n63 60 39 65 87\n\n27 56 90 44 60\n48 68 47 96 73\n75 13 80 12 38\n81 21 20 46 97\n67  6 72 76  2\n\n33 96  4 55 49\n74 43 54  6 51\n30  0 75 28 62\n90 81  2 83 68\n39 95 70 84 42\n\n97 22 15 30 45\n92 96 50 16 42\n39 23 89 21  2\n72 98 58 48 82\n94 11  1 86 84\n\n41 13 84 51 76\n33 63  0 62 18\n81 32 57 68 21\n20 64 47 24 93\n 7 56 27 66 30\n\n52 81 85 92  3\n15 91 19 13 93\n36 77 74 37 26\n67 16 73 89 33\n43 90 38 31 29\n\n 1 52 96 66 86\n30 15 26 82 42\n 8 94 41 54  5\n84 23 72 77  7\n34 53 18 69 90\n\n 7 67 35  2 36\n91 51 56 85 32\n98 22 76 97 71\n70 29 68 44  1\n 8 80 42 46 93\n\n 4 13 90 64 97\n44 28 17 42 18\n72 77 11 35 22\n25 73 41  1 26\n51  8 92 43  2\n\n 6 68 51 73 39\n32 60 34 74 18\n 5 95 11  8 62\n23  3 70 94 54\n36 20 29 10 26\n\n66 80 77 82 62\n95 25 33 50 14\n94  0 91 46 23\n59 47 96 26 15\n69  6  2 34 75\n\n72 66 35 81 69\n48 44 11 16 40\n94  5  3 51 54\n89  6 78 37 59\n76 45  8 18 10\n\n30 46 96 56 69\n66 29 32 74  4\n85 84 99 87 92\n22 50 64 15 57\n78 47  1 48 10\n\n66 48 90 67 23\n 3 21 73 71 18\n97 52 64 80 94\n49 42 75 47 38\n 4 28 19 68 57\n\n53 46 56 84 57\n55 45 85 89 76\n80 26  2 36 23\n92 10 30 18 69\n67 49 21  8 44\n\n51 47 85 41  8\n70 34 98 30 16\n82 22 18 95 73\n65 21 49  5 15\n56 19 17 23 46\n\n25 28 47 84  8\n35 90 13 39 15\n50 86 41 33 51\n57 73 87 45  5\n31 22 48  7 27\n\n79 71 64 87 21\n10 73  1 40  9\n36 84 80  6 60\n19 81 55 50 56\n67 23 62 86 63\n\n87 45 56 67 13\n 8 79 31 48 86\n32 15 88  6 66\n62 27 44 26 99\n64 63  3 70 90\n\n84 87 89 71  2\n63 67 72  3 75\n39 44 54 20 85\n 1 97 14 37 98\n25 66 92 17 57\n\n27 34 64 60 87\n77 29 21 56 23\n79 53 75 72 69\n95 16 85 52 70\n92 65 62 33 15\n\n42 87 96 79 90\n97 77 58 62 55\n11 86 68 44 52\n93 23  1 61 60\n47 72 14 28 13\n\n14 78 68 48 74\n50 32 29 24 54\n73 99 57 90 64\n12 76 62 15 44\n70 58 22  1 85\n\n49  2 75 88 87\n71 61 95  5 38\n99 86 67  8 83\n17 11  9 54 33\n70 78 62  1 58\n\n11 44 53 73 13\n45 95 15 63 49\n94 34 99 64 10\n78  9 67 12 20\n50 97 96 89 14\n\n55  3 72 93 81\n25 43 60 85 26\n96 45 53 19 40\n73 42 76 47 80\n74 69 22 23 89\n\n24 59 62 91  5\n51 75 76 29 35\n86 96 94 66 55\n87 61 82 40 32\n28 22 27 21 49\n\n66 80 82 46 13\n97 67 41 63  1\n65 89 22 12 15\n94 96  9 91 48\n85  3 60 95  8\n\n57 90 97 56 33\n79 15 75 70 41\n21 26 20 98 81\n18 36 24 76 35\n42 27 11 67  0\n\n89 31 86 10 13\n81  8 16  0 77\n92 67 39 96 74\n90  7 75 55 65\n51  2 97 58 17\n\n92 55  4 83 93\n31 21 74 73 68\n18 41 32 17 77\n56 94 98 72 87\n19  6 49 11 37\n\n15 79 24 60 91\n25 41 63 32 56\n13 83 69  0 57\n77  7 62 45 98\n64 37 94 55  9\n\n81 42 29 98 44\n16 83 27 92 60\n22 63 79 64 45\n80 38 56  5  2\n 0  4 34 37 59\n\n90 85 32 97 52\n69 37 57 29 51\n22  4 99 67 84\n 0  2 76 34 47\n63 96 94 83 40\n\n72 68 70 40 39\n22  7 62 46 76\n25 31 41 71  9\n30 52 78 26 10\n53 17 45 16 98\n\n66 39 96 16 67\n46 34 27 49  2\n93 25 50 70 57\n33 69 64 30 45\n10 91 20 18  3\n\n32 35 71 62 43\n24 57 46 39 87\n28 21 26 31 52\n99 60 14  6 97\n 1 44 89 33 93\n\n47 15 21 23 20\n 4 50  6 93 44\n38 53  2 45 42\n83 57 63 17 24\n99  5 34 66  0\n\n65 91 60 50 62\n16  2 51 14 32\n81 17 58 59 77\n29 98 72 28  3\n15 99 49 37  5\n\n62 23 48 80 28\n68  2 71 89 36\n13 95 64 98  8\n60 86 51 74 11\n35 27 66 78  7\n\n65  9 57 85 30\n29 52 27 83 98\n 7 48 45 21 93\n 5 71 54 34 91\n96 87 25 84 63\n\n38 94 65 69 18\n79 81 80 36 91\n17  2 23 53 98\n92 68 21 74 55\n 3 58 72 70 86").Split('\n', StringSplitOptions.RemoveEmptyEntries);
    private IList<Board> boards = new List<Board>();
    
    public Day4()
    {
        for (int i = 0; i < boardNumbers.Length; i += 5)
        {
            boards.Add(new Board(i / 5, new[]
            {
                boardNumbers[i], boardNumbers[i + 1], boardNumbers[i + 2], boardNumbers[i + 3], boardNumbers[i + 4]
            }));
        }

        int remainingValuesSum = 0;
        Board lastBoard = null;
        for (int i = 0; i < drawNumbers.Length; i++)
        {
            foreach (var board in boards.ToList())
            {
                if (board.MarkNumber(int.Parse(drawNumbers[i])))
                {
                    board.bingo = true;
                    if (remainingValuesSum == 0)
                    {
                        remainingValuesSum = board.GetRemainingValues();
                        Console.WriteLine(
                            $"A: remaining sum: {remainingValuesSum}, Last number: {int.Parse(drawNumbers[i])} Final score: {remainingValuesSum * int.Parse(drawNumbers[i])}");
                        boards.Remove(board);
                    }
                }
            }
            
            if (boards.Count(x => !x.bingo) == 1)
            {
                lastBoard = boards.Single(x => !x.bingo);
            }
            
            if (boards.All(x => x.bingo))
            {
                Console.WriteLine($"B: final score of the losing board: id:{lastBoard.ID}, Last number: {int.Parse(drawNumbers[i])}, {lastBoard.GetRemainingValues() * int.Parse(drawNumbers[i])}");
                break;
            }
            
            
        }
        
        
    }

    private class Board
    {
        public int ID;
        public bool bingo;
        public number[][] numbers = new number[5][];

        internal bool MarkNumber(int val)
        {
            var fullRow = false;
            foreach (var row in numbers)
            {
                row.Where(x => x.value == val).ToList().ForEach(x => x.marked = true);
            }

            for (int i = 0; i < 5; i++)
            {
                if (numbers[i].All(x => x.marked) || numbers.All(x => x.ElementAt(i).marked))
                    fullRow = true;
            }
            

            return fullRow;
        }

        internal int GetRemainingValues()
        {
            var sum = 0;
            foreach (var row in numbers)
            {
                row.Where(x => !x.marked).ToList().ForEach(x => sum += x.value);
            }

            return sum;
        }
        
        public Board(int id, string[] input)
        {
            for (var i = 0; i < input.Length; i++)
                numbers[i] = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => new number(int.Parse(x))).ToArray();
            ID = id;
        }

        internal class number
        {
            internal bool marked { get; set; }
            internal int value;

            public number(int val)
            {
                value = val;
                marked = false;
            }
        }
    }
}