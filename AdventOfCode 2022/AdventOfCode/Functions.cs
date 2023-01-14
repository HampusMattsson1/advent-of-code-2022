using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class Days
{
    public string[] ReadFile(string path)
    {
        // Read a text file line by line.  
        //string[] lines = File.ReadAllLines(path);

        //foreach (string line in lines)
        //    Console.WriteLine(line);

        return File.ReadAllLines(path);
    }


    public void Day1()
    {
        string[] input = ReadFile("../../../Input/day1.txt");

        int sumPrev;
        int sum = 0;
        int currentWinner = 0;

        List<int> Results = new List<int>();

        foreach (string line in input)
        {
            if (Int32.TryParse(line, out int n))
            {
                sum += n;
            } else
            {
                Results.Add(sum);

                if (sum > currentWinner)
                {
                    currentWinner = sum;
                }
               
                sumPrev = sum;
                sum = 0;
            }
        }

        if (sum > currentWinner)
        {
            currentWinner = sum;
        }

        Console.WriteLine("Day1 Part1: " + currentWinner);

        Results.Sort();
        Results.Reverse();

        var TotalTop3 = 0;

        for (int i = 0; i < 3; i++)
        {
            TotalTop3 += Results[i];
        }

        Console.WriteLine("Day2 Part2: " + TotalTop3);
    }


    public void Day2()
    {
        string[] input = ReadFile("../../../Input/day2.txt");

        int totalPoints1 = 0;
        int totalPoints2 = 0;

        foreach (var line in input)
        {
            string[] round = line.Split(' ');
            int points = 0;
            int partTwo = 0;

            switch (round[1])
            {
                case "X":
                    points += 1;

                    // Lose
                    partTwo += 0;

                    if (round[0] == "A")
                    {
                        points += 3;

                        //Scissors
                        partTwo += 3;
                    }
                    if (round[0] == "B")
                    {
                        points += 0;

                        // Rock
                        partTwo += 1;
                    }
                    if (round[0] == "C")
                    {
                        points += 6;

                        // Paper
                        partTwo += 2;
                    }
                    break;

                case "Y":
                    points += 2;

                    // Tie
                    partTwo += 3;

                    if (round[0] == "A")
                    {
                        points += 6;

                        // Rock
                        partTwo += 1;
                    }
                    if (round[0] == "B")
                    {
                        points += 3;

                        // Paper
                        partTwo += 2;
                    }
                    if (round[0] == "C")
                    {
                        points += 0;

                        // Scissors
                        partTwo += 3;
                    }
                    break;

                case "Z":
                    points += 3;

                    // Win
                    partTwo += 6;

                    if (round[0] == "A")
                    {
                        points += 0;

                        // Paper
                        partTwo += 2;
                    }
                    if (round[0] == "B")
                    {
                        points += 6;

                        // Scissors
                        partTwo += 3;
                    }
                    if (round[0] == "C")
                    {
                        points += 3;

                        // Rock
                        partTwo += 1;
                    }
                    break;
            }

            totalPoints1 += points;
            totalPoints2 += partTwo;
        }

        Console.WriteLine("Day2 Part 1: " + totalPoints1);
        Console.WriteLine("Day2 Part 2: " + totalPoints2);
    }


    public void Day3()
    {
        string[] input = ReadFile("../../../Input/day3.txt");
        //string[] input = ReadFile("../../../test.txt");

        // Dictionary for values
        Dictionary<char, int> Values = new Dictionary<char, int>()
        {
            ['a'] = 1,
            ['b'] = 2,
            ['c'] = 3,
            ['d'] = 4,
            ['e'] = 5,
            ['f'] = 6,
            ['g'] = 7,
            ['h'] = 8,
            ['i'] = 9,
            ['j'] = 10,
            ['k'] = 11,
            ['l'] = 12,
            ['m'] = 13,
            ['n'] = 14,
            ['o'] = 15,
            ['p'] = 16,
            ['q'] = 17,
            ['r'] = 18,
            ['s'] = 19,
            ['t'] = 20,
            ['u'] = 21,
            ['v'] = 22,
            ['w'] = 23,
            ['x'] = 24,
            ['y'] = 25,
            ['z'] = 26,

            ['A'] = 27,
            ['B'] = 28,
            ['C'] = 29,
            ['D'] = 30,
            ['E'] = 31,
            ['F'] = 32,
            ['G'] = 33,
            ['H'] = 34,
            ['I'] = 35,
            ['J'] = 36,
            ['K'] = 37,
            ['L'] = 38,
            ['M'] = 39,
            ['N'] = 40,
            ['O'] = 41,
            ['P'] = 42,
            ['Q'] = 43,
            ['R'] = 44,
            ['S'] = 45,
            ['T'] = 46,
            ['U'] = 47,
            ['V'] = 48,
            ['W'] = 49,
            ['X'] = 50,
            ['Y'] = 51,
            ['Z'] = 52,
        };

        int prioritySum = 0;

        List<string> sacks = new List<string>();
        int count = 0;
        int sum2 = 0;

        foreach (string line in input)
        {
            // Split line in two
            string rucksack1 = line.Substring(0, line.Length / 2);
            string rucksack2 = line.Substring(line.Length / 2, rucksack1.Length);

            char equal = 'a';

            foreach (char c in rucksack1)
            {
                if (rucksack2.Contains(c))
                {
                    equal = c;
                    break;
                }
            }

            prioritySum += Values[equal];


            // part 2
            if (count < 3)
            {
                sacks.Add(line);
                count++;
            } else
            {
                count = 0;

                foreach (char c in sacks[0])
                {
                    if (sacks[1].Contains(c) && sacks[2].Contains(c))
                    {
                        equal = c;
                        break;
                    }
                }
                sacks.Clear();
            }

            sum2 += Values[equal];
        }

        Console.WriteLine("Day3 Part 1: " + prioritySum);

        Console.WriteLine("Day3 Part 2: " + sum2);
    }


    public void Day4()
    {
        string[] input = ReadFile("../../../Input/day4.txt");
        //string[] input = ReadFile("../../../test.txt");

        int containRanges = 0;
        int overlaps = 0;

        foreach (string line in input)
        {
            string[] strings = line.Split(',');

            int[] currentRange1 = new int[2];
            currentRange1[0] = int.Parse(strings[0].Split('-')[0]);
			currentRange1[1] = int.Parse(strings[0].Split('-')[1]);

			int[] currentRange2 = new int[2];
			currentRange2[0] = int.Parse(strings[1].Split('-')[0]);
			currentRange2[1] = int.Parse(strings[1].Split('-')[1]);

            // Contains
            if (currentRange1[0] <= currentRange2[0] && currentRange1[1] >= currentRange2[1]){
                containRanges++;
            }
			else if (currentRange2[0] <= currentRange1[0] && currentRange2[1] >= currentRange1[1])
			{
				containRanges++;
			}

            // Overlaps
            if (currentRange1[0] >= currentRange2[0] && currentRange1[0] <= currentRange2[1])
            {
                overlaps++;
            }
            else if (currentRange1[1] >= currentRange2[0] && currentRange1[1] <= currentRange2[1])
            {
                overlaps++;
            }

			else if (currentRange2[0] >= currentRange1[0] && currentRange2[0] <= currentRange1[1])
			{
				overlaps++;
			}
			else if (currentRange2[1] >= currentRange1[0] && currentRange2[1] <= currentRange1[1])
			{
				overlaps++;
			}
		}

        Console.WriteLine("Day4 Part 1: " + containRanges);
		Console.WriteLine("Day4 Part 2: " + overlaps);
	}


    public void Day5()
    {
        string[] input = ReadFile("../../../Input/day5.txt");
        //string[] input = ReadFile("../../../test.txt");

        char[] arr1 = new char[] { 'D', 'B', 'J', 'V' };
        char[] arr2 = new char[] { 'P', 'V', 'B', 'W', 'R', 'D', 'F'};
        char[] arr3 = new char[] { 'R', 'G', 'F', 'L', 'D', 'C', 'W', 'Q' };
        char[] arr4 = new char[] { 'W', 'J', 'P', 'M', 'L', 'N', 'D', 'B' };
		char[] arr5 = new char[] { 'H', 'N', 'B', 'P', 'C', 'S', 'Q' };
		char[] arr6 = new char[] { 'R', 'D', 'B', 'S', 'N', 'G' };
		char[] arr7 = new char[] { 'Z', 'B', 'P', 'M', 'Q', 'F', 'S', 'H' };
		char[] arr8 = new char[] { 'W', 'L', 'F' };
		char[] arr9 = new char[] { 'S', 'V', 'F', 'M', 'R' };

        // Test example
		//char[] arr1 = new char[] { 'Z', 'N' };
		//char[] arr2 = new char[] { 'M', 'C', 'D' };
		//char[] arr3 = new char[] { 'P' };

		List<Stack<char>> stacks = new List<Stack<char>>
		{
			new Stack<char>(arr1),
			new Stack<char>(arr2),
			new Stack<char>(arr3),
            new Stack<char>(arr4),
            new Stack<char>(arr5),
            new Stack<char>(arr6),
            new Stack<char>(arr7),
            new Stack<char>(arr8),
            new Stack<char>(arr9)
        };

        //Console.WriteLine("Before: ");
        //for (int i = 0; i < stacks.Count; i++)
        //{
        //    string stackLine = i + 1 + ": ";
        //    foreach (var s in stacks[i])
        //    {
        //        stackLine += s;
        //    }
        //    Console.WriteLine(stackLine);
        //}

        int count = 0;

        foreach (string line in input)
        {
            count++;
            if (count >= 11)
            {
                string[] actions = line.Split(' ');

                List<string> toMove = new List<string>();

                int toMoveCount = Int32.Parse(actions[1]);

                //Console.WriteLine("\n--- LINE ---");
                //Console.WriteLine(line);
                //Console.WriteLine("toMoveCount: " + toMoveCount);
                //Console.WriteLine("From: " + Int32.Parse(actions[3]));
                //Console.WriteLine("To: " + Int32.Parse(actions[5]));

                // From
                for (int i = 0; i < toMoveCount; i++)
                {
                    var item = stacks[Int32.Parse(actions[3]) - 1].Pop();
                    toMove.Add(item.ToString());
				}

                // Kommentera ut för att lösa part 2
                toMove.Reverse();

                for (int i = toMoveCount-1; i >= 0; i--)
				{
                    stacks[Int32.Parse(actions[5])-1].Push(toMove[i][0]);
                }

                //Console.WriteLine("RES: ");
                //for (int i = 0; i < stacks.Count; i++)
                //{
                //    string stackLine = i + 1 + ": ";

                //    var temp = stacks[i].Reverse();
                //    foreach (var s in temp)
                //    {
                //        stackLine += s;
                //    }
                //    Console.WriteLine(stackLine);
                //}
            }
            
        }

        //Console.WriteLine("\nResult: ");
        //for (int i = 0; i < stacks.Count; i++)
        //{
        //    string stackLine = i + 1 + ": ";
        //    foreach (var s in stacks[i])
        //    {
        //        stackLine += s;
        //    }
        //    Console.WriteLine(stackLine);
        //}

        var finalString = "";
        foreach (var stack in stacks)
        {
            finalString += stack.Peek();
        }

        Console.WriteLine("Day5 Part 1/2: " + finalString);

    }


    public void Day6()
    {
        string[] input = ReadFile("../../../Input/day6.txt");
        //string[] input = ReadFile("../../../test.txt");

        string temp = "";
        int charCount = 0;
        int count = 0;

        foreach (var c in input[0])
        {
            if (charCount == 14)
            {
                break;
            }

            if (temp.Contains(c))
            {
                //Console.WriteLine("temp: " + temp);

                var temp2 = string.Join("", temp.ToCharArray().Reverse().ToArray());

                //Console.Write("temp2: ");
                //foreach (var t in temp2)
                //{
                //    Console.Write(t);
                //}

                int toRemove = 1;

                foreach (var c2 in temp)
                {
                    if (c2 == c)
                    {
                        break;
                    }
                    toRemove++;
                }

                //Console.WriteLine("\ntoRemove: " + toRemove);

                temp = string.Join("", temp2.Remove(temp2.Length - toRemove).Reverse().ToArray());

                //Console.WriteLine("temp: " + temp);

                charCount -= toRemove;
            }
            

            temp += c;
            charCount++;

            count++;
        }

        //Console.Write("temp: " + temp);

        Console.WriteLine("Day6 Part 1/2: " + count);
    }




    class dir_entry
    {
        public dir_entry? root = null;

        public bool isFile = false;

        public string name = "";
        public int size = 0;

        public List<dir_entry> entries = new List<dir_entry>();

        public void print(int depth = 0)
        {
            //Console.WriteLine("--- PRINTING ---");
            //Console.WriteLine("--- INSIDE: " + name);

            foreach (var item in entries)
            {
                string tabs = new string(' ', depth);
                Console.WriteLine(tabs+item.name);

                if (item.isFile == false && item.entries.Count > 0)
                {
                    item.print(depth + 2);
                }
            }
        }

        public int calculateSize()
        {
            int totalSize = 0;

            foreach (var item in entries)
            {
                if (item.entries.Count > 0)
                {
                    totalSize += item.calculateSize();
                }

                if (item.isFile)
                {
                    totalSize+= item.size;
                }
            }

            return totalSize;
        }
    };

    public void Day7()
    {
        string[] input = ReadFile("../../../Input/day7.txt");
        //string[] input = ReadFile("../../../test.txt");

        dir_entry root = new dir_entry
        {
            name = "root",
            root = null
        };

        dir_entry currentDir = root;

        List<int> directorySizes = new List<int>();


        foreach (var line in input)
        {
            string[] commands = line.Split(' ');

            //Console.WriteLine("--- LINE: " + line);

            if (commands[0] == "$")
            {
                switch (commands[1])
                {
                    case "cd":
                        // Traverse
                        if (commands[2] == "..")
                        {
                            // calculate and save size of the directory
                            directorySizes.Add(currentDir.calculateSize());

                            currentDir = currentDir.root;
                        }
                        else if (commands[2] == "/")
                        {
                            directorySizes.Add(currentDir.calculateSize());
                            currentDir = root;
                        }
                        else
                        {
                            foreach (var dir in currentDir.entries)
                            {
                                if (dir.name == commands[2])
                                {
                                    currentDir = dir;
                                    break;
                                }
                            }
                        }
                        break;


                    case "ls":
                        break;
                }
            }
            else
            {
                // Dir
                if (commands[0] == "dir")
                {
                    var newDir = new dir_entry
                    {
                        root = currentDir,
                        name = commands[1],
                        isFile = false,
                        entries = new List<dir_entry>()
                    };
                    currentDir.entries.Add(newDir);
                }
                else // File
                {
                    dir_entry newDir = new dir_entry
                    {
                        root = currentDir,
                        name = commands[1],
                        isFile = true,
                        size = Int32.Parse(commands[0]),
                        entries = new List<dir_entry>()
                    };
                    currentDir.entries.Add(newDir);
                }
            }
            //Console.WriteLine("------------- NOW IN: " + currentDir->name);
        }

        //root.print();
        //Console.WriteLine("STOPS AT: " + currentDir.name);

        Console.WriteLine("Total size of root = " + root.calculateSize());

        // add root directory
        directorySizes.Add(root.calculateSize());

        directorySizes.Sort();
        directorySizes.Reverse();

        int sum = 0;

        for (int i = 0; i < directorySizes.Count; i++)
        {
            if (directorySizes[i] <= 100000)
            {
                Console.WriteLine("directory size: " + directorySizes[i]);
                sum += directorySizes[i];
            }
        }

        Console.WriteLine("Day7 Part 1: " + sum);

        //foreach (var dir in directorySizes)
        //{
        //    Console.WriteLine("directory size: " + dir);
        //}

    }


    private bool inFoundTrees(List<string> trees, int x, int y)
    {
        foreach (string tree in trees)
        {
            string[] cords = tree.Split(',');
            if (Int32.Parse(cords[0]) == x && Int32.Parse(cords[1]) == y)
            {
                return true;
            }
        }


        return false;
    }


    public bool seenFromSides(int[,] grid, int x, int y, int totalWidth)
    {
        bool[] canBeSeen = { false, false, false, false };

        int currentTallest = grid[0, y];

        // Left
        for (int i = 0; i < x; i++)
        {
            if (grid[i, y] > currentTallest)
            {
                currentTallest = grid[i, y];
                canBeSeen[0] = true;
            }
            else if (grid[i, y] == currentTallest)
            {
                canBeSeen[0] = false;
            }
        }

        // Top
        currentTallest = grid[y, 0];
        for (int i = 0; i < y; i++)
        {
            if (grid[y, i] > currentTallest)
            {
                currentTallest = grid[y, i];
                canBeSeen[1] = true;
            }
            else if (grid[y, i] == currentTallest)
            {
                canBeSeen[1] = false;
            }
        }

        // Right
        currentTallest = grid[0, y];
        for (int i = x-1; i >= 0; i--)
        {
            if (grid[i, y] > currentTallest)
            {
                currentTallest = grid[i, y];
                canBeSeen[2] = true;
            }
            else if (grid[i, y] == currentTallest)
            {
                canBeSeen[2] = false;
            }
        }

        // Bottom
        currentTallest = grid[y, 0];
        for (int i = y-1; i >= 0; i--)
        {
            if (grid[y, i] > currentTallest)
            {
                currentTallest = grid[y, i];
                canBeSeen[3] = true;
            }
            else if (grid[y, i] == currentTallest)
            {
                canBeSeen[3] = false;
            }
        }

        
        // Set temp single var
        foreach (var b in canBeSeen)
        {
            if (b == true)
            {
                return true;
            }
        }

        return false;
    }


    public void Day8()
    {
        //string[] input = ReadFile("../../../Input/day8.txt");
        string[] input = ReadFile("../../../test.txt");

        int x = input[0].Length, y = input.Length;

        int foundTrees = 0;
        List<string> trees = new();

        // grid
        int[,] grid = new int[x,y];

        // fill grid
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                grid[j, i] = Int32.Parse(input[i][j].ToString());
            }
        }

        Console.WriteLine("X: " + x);
        Console.WriteLine("Y: " + y);


        // Add all outer trees
        foundTrees += x * 2 + ((x-2) * 2);


        // Nytt test med en for-loop
        for (int i = 1; i < y - 1; i++)
        {
            int innerJumps = 1;
            //Console.WriteLine("loop: " + i);

            while (innerJumps < x - 1)
            {
                // Skip if already in found trees
                if (inFoundTrees(trees, innerJumps, i))
                {
                    innerJumps++;
                    continue;
                }

                // Compare with all sides
                if (seenFromSides(grid, innerJumps, i, x))
                {
                    foundTrees++;
                    string str = innerJumps + "," + i;
                    trees.Add(str);

                    //Console.WriteLine("Added tree: ("+innerJumps+","+i+") value: " + grid[innerJumps, i]);
                }

                innerJumps++;
            }
        }

        Console.WriteLine("foundTrees: " + foundTrees);
    }


}