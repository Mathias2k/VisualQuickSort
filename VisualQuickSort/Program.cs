using System.Text.RegularExpressions;
using VisualQuickSort;

public class Program
{
    static void Main()
    {
        try
        {
            bool done = false;
            while (!done)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--- Select return type for QuickSorted algorithm---");
                Console.WriteLine("Press 1 - List Sorted Results");
                Console.WriteLine("Press 2 - Visual Sorted Results");
                Console.WriteLine("Press 3 - Raw Sorted Results");
                Console.WriteLine("Press 4 - Close");
                Console.WriteLine("Then Press Enter");
                Console.ForegroundColor = ConsoleColor.Blue;

                string? input = Console.ReadLine();
                Console.Beep();
                if (Regex.IsMatch(input ?? "nullchar", @"^[a-zA-Z]+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Press a correct type");
                }
                else if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Press a correct type");
                }
                else if (input != "1" &&
                         input != "2" &&
                         input != "3" &&
                         input != "4")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Press a correct type");
                }
                else if (input == "4")
                    return;
                else
                {
                    int type = Convert.ToInt32(input);
                    string? arrayLengthAux = string.Empty;
                    int[] sortedArray = Array.Empty<int>();
                    int[] array = Array.Empty<int>();

                    bool done2 = false;
                    while (!done2)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press number for List Length");
                        Console.WriteLine("Then Press Enter");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        arrayLengthAux = Console.ReadLine();
                        Console.Beep();
                        if (Regex.IsMatch(arrayLengthAux ?? "nullchar", @"^[a-zA-Z]+$"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Press a number");
                        }
                        else if (string.IsNullOrEmpty(arrayLengthAux))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Press a number");
                        }
                        else
                            done2 = true;
                    }

                    Random random = new();
                    int arrayLength = Convert.ToInt32(arrayLengthAux);
                    array = new int[arrayLength];
                    string numbersOutput;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("Random numbers to be sorted:");
                    for (int i = 0; i < arrayLength; i++)
                        array[i] = random.Next(100);

                    numbersOutput = string.Join(",", array.ToList());
                    Console.WriteLine($"{numbersOutput} \n");
                    Thread.Sleep(3000);

                    sortedArray = SortArray(array, 0, array.Length - 1, type);

                    if (type == (int)EnumTypeReturn.List)
                    {
                        for (int i = 0; i < sortedArray.Length; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(sortedArray[i]);
                        }
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static int[] SortArray(int[] array, int leftIndex, int rightIndex, int type)
    {
        if (type == (int)EnumTypeReturn.Visual)
        {
            for (int a = 0; a < array.Length; a++)
                LineHorizontale(array[a]);
        }

        if (type == (int)EnumTypeReturn.Raw)
        {
            for (int b = 0; b < array.Length; b++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{array[b]}  ");
            }
            Console.WriteLine();
        }

        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];
        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }

            while (array[j] > pivot)
            {
                j--;
            }

            if (i <= j)
            {
                (array[j], array[i]) = (array[i], array[j]);
                i++;
                j--;
            }
        }

        if (leftIndex < j)
            SortArray(array, leftIndex, j, type);
        if (i < rightIndex)
            SortArray(array, i, rightIndex, type);

        return array;
    }
    public static void LineHorizontale(int length)
    {
        for (var i = 0; i < length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("*");
        }

        Console.WriteLine();
    }
}