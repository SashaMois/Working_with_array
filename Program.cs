using System;
using System.Linq;

namespace Working_with_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[1]; // array for work
            int size = 0; // size of array
            int result = 0; // for save single result

            // initializing the array
            {
                Console.WriteLine("Hello, User! Let's start a work!\n");
                Console.WriteLine("Input a size of array\n(size must be more than 0):");
            }

            do
            {
                if (!int.TryParse(Console.ReadLine(), out size))
                    Console.WriteLine("\nYour input is wrong! Please, try again.");
                else
                {
                    array = Enumerable.Repeat(0, size).ToArray();
                    break;
                }
            } while (true);

            // input a numbers to array
            Console.WriteLine("Input some numbers for save them in the array:");
            for (int i = 0; i < array.Length; ++i)
                try
                {
                    array[i] = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\nYour input is wrong! Please, try again.");
                    --i;
                }

            // an offer to do anything with this array
            do
            {
                const int COUNT_OF_VARIANTS = 27;
                int[] multiply_result; //  for save multiply result
                int action = 0; // choose variant of 27 available
                {
                    Console.WriteLine("\nChoose action for change array:");
                    Console.WriteLine
                    (
                        $"\b{1: 00}. Find maximal number;\n" +
                        $"\b{2: 00}. Find minimal number;\n" +
                        $"\b{3: 00}. Find numbers lower than input number;\n" +
                        $"\b{4: 00}. Find numbers more than input number;\n" +
                        $"\b{5: 00}. Find numbers equal input number;\n" +
                        $"\b{6: 00}. Find first number lower than input number;\n" +
                        $"\b{7: 00}. Find last number lower than input number;\n" +
                        $"\b{8: 00}. Find first number more than input number;\n" +
                        $"\b{9: 00}. Find last number more than input number;\n" +
                        "10. Find first number to equal input number;\n" +
                        "11. Find last number to equal input number;\n" +
                        "12. Find the same array's elements;\n" +
                        "13. Find summary of array's elements;\n" +
                        "14. Find all even numbers of array;\n" +
                        "15. Find all odd numbers of array;\n" +
                        "16. Find summary of even numbers of array;\n" +
                        "17. Find summary of odd numbers of array;\n" +
                        "18. Find maximal odd number of array;\n" +
                        "19. Find minimal odd number of array;\n" +
                        "20. Find maximal even number of array;\n" +
                        "21. Find minimal even number of array;\n" +
                        "22. Reverse array;\n" +
                        "23. Order array;\n" +
                        "24. Order in reverse array;\n" +
                        "25. Input current state of array;\n" +
                        "26. Input current state of variable;\n" +
                        "27. Exit the program.\n"
                    );
                }
                // choose one of the offers
                Console.Write("Input a number of action: ");
                string readed = Console.ReadLine();
                if (readed == "exit" || readed == "Exit" || readed == "EXIT") // condition for give an opportunity for user to live from program
                {
                    Console.WriteLine("Good Bye!");
                    return;
                }

                do
                {
                    int.TryParse(readed, out action);
                    if (action <= 0 || action > COUNT_OF_VARIANTS)
                        Console.WriteLine("Your choose doesn't exist! Please, try again.");
                    else
                        break;

                } while (true);

                bool isSave = false;
                if (action != 25 && action != 26 && action != 27)
                {
                    Console.Write("Will this action change array or save its result in variable?(y/n)...");

                    char answer;

                    do
                    {
                        try
                        {
                            if (char.TryParse(Console.ReadLine(), out answer) && (answer == 'y' || answer == 'Y'))
                            {
                                isSave = true;
                                break;
                            }
                            else
                            {
                                isSave = false;
                                break;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Your choose doesn't exist! Please, try again.");
                        }
                    }
                    while (true);
                    Console.WriteLine();
                }

                // working with choosed variant
                {
                    int saver; // save input

                    switch (action)
                    {
                        case 1:
                            if (isSave)
                            {
                                result = array.Max();
                                Console.WriteLine("Succesfully save!\n");
                            }
                            else
                                Console.WriteLine("Max: " + array.Max() + '\n');
                            break;
                        case 2:
                            if (isSave)
                            {
                                result = array.Min();
                                Console.WriteLine("Succesfully save!");
                            }
                            else
                                Console.WriteLine("Min: " + array.Min());
                            break;
                        case 3:
                            Console.Write("Input a number: ");
                            Console.WriteLine();
                            while (!int.TryParse(Console.ReadLine(), out saver))
                                Console.WriteLine("\n\nIt isn't truth number! Please, try again.");

                            if (isSave)
                            {
                                try
                                {
                                    array = array.Where(i => i < saver).ToArray();
                                    Console.WriteLine("Succesfully save!");
                                }
                                catch
                                {
                                    Console.WriteLine("Such a number(s) doesn't exist in this array.\n" +
                                                      "The array has remained unchanged! ");
                                }
                            }
                            else
                            {
                                try
                                {
                                    multiply_result = array.Where(i => i < saver).ToArray();

                                    Console.Write("Result: ");
                                    for (int i = 0; i < multiply_result.Length; ++i)
                                        Console.Write($"{multiply_result[i]} ");
                                    Console.WriteLine();
                                }
                                catch
                                {
                                    Console.WriteLine("Such a number(s) doesn't exist in this array.");
                                }
                            }
                            break;
                        case 4:
                            Console.Write("Input a number: ");
                            Console.WriteLine();
                            while (!int.TryParse(Console.ReadLine(), out saver))
                                Console.WriteLine("\n\nIt isn't truth number! Please, try again.");
                            if (isSave)
                            {
                                array = array.Where(i => i > saver).ToArray();
                                Console.WriteLine("Succesfully save!");
                            }
                            else
                            {
                                multiply_result = array.Where(i => i > saver).ToArray();

                                Console.Write("Result: ");
                                for (int i = 0; i < multiply_result.Length; ++i)
                                    Console.Write($"{multiply_result[i]} ");
                                Console.WriteLine();
                            }
                            break;
                        case 5:
                            Console.Write("Input a number:");
                            Console.WriteLine();
                            while (!int.TryParse(Console.ReadLine(), out saver))
                                Console.WriteLine("\n\nIt isn't truth number! Please, try again.");

                            if (isSave)
                            {
                                array = array.Where(i => i == saver).ToArray();
                                Console.WriteLine("Succesfully save!");
                            }
                            else
                            {
                                multiply_result = array.Where(i => i == saver).ToArray();

                                Console.Write("Result: ");
                                for (int i = 0; i < multiply_result.Length; ++i)
                                    Console.Write($"{multiply_result} ");
                                Console.WriteLine();
                            }
                            break;
                        case 6:
                            Console.Write("Input a number:");
                            while (!int.TryParse(Console.ReadLine(), out saver))
                                Console.WriteLine("\n\nIt isn't truth number! Please, try again.");

                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i < saver).First();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i < saver).First());
                            }
                            catch
                            {
                                Console.WriteLine("Such number doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                        case 7:
                            Console.Write("Input a number:");
                            Console.WriteLine();
                            while (!int.TryParse(Console.ReadLine(), out saver))
                                Console.WriteLine("\n\nIt isn't truth number! Please, try again.");

                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i < saver).Last();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i < saver).Last());
                            }
                            catch
                            {
                                Console.WriteLine("Such number doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                        case 8:
                            Console.Write("Input a number:");
                            Console.WriteLine();
                            while (!int.TryParse(Console.ReadLine(), out saver))
                                Console.WriteLine("\n\nIt isn't truth number! Please, try again.");

                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i > saver).First();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i > saver).First());
                            }
                            catch
                            {
                                Console.WriteLine("Such number doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                        case 9:
                            Console.Write("Input a number: ");
                            Console.WriteLine();
                            while (!int.TryParse(Console.ReadLine(), out saver))
                                Console.WriteLine("\n\nIt isn't trutn number! Please, try again.");

                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i > saver).Last();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i > saver).Last());
                            }
                            catch
                            {
                                Console.WriteLine("Such number doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                        case 10:
                            Console.Write("Input a number: ");
                            Console.WriteLine();
                            while (!int.TryParse(Console.ReadLine(), out saver))
                                Console.WriteLine("\n\nIt isn't truth number! Please, try again.");

                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i == saver).First();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i == saver).First());
                            }
                            catch
                            {
                                Console.WriteLine("Such number doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                        case 11:
                            Console.Write("Input a number:");
                            Console.WriteLine();
                            while (!int.TryParse(Console.ReadLine(), out saver))
                                Console.WriteLine("\n\nIt isn't truth number! Please, try again.");

                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i == saver).Last();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i == saver).Last());
                            }
                            catch
                            {
                                Console.WriteLine("Such number doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                       case 12:
                            if (isSave)
                            {
                                array = array.Distinct().ToArray();
                                Console.WriteLine("Succesfully save!");
                            }
                            else
                            {
                                multiply_result = array.Distinct().ToArray();

                                Console.Write("Result: ");
                                for (int i = 0; i < multiply_result.Length; ++i)
                                    Console.Write($"{multiply_result[i]} ");
                                Console.WriteLine();
                            }
                            break;
                        case 13:
                            if (isSave)
                            {
                                result = array.Sum();
                                Console.WriteLine("Succesfully save!");
                            }
                            else
                                Console.WriteLine("Result: " + array.Sum());
                            break;
                        case 14:
                            if (isSave)
                            {
                                array = array.Where(i => i % 2 != 0).ToArray();
                                Console.WriteLine("Succesfully save!");
                            }
                            else
                            {
                                multiply_result = array.Where(i => i % 2 == 0).ToArray();

                                Console.Write("Result: ");
                                for (int i = 0; i < multiply_result.Length; ++i)
                                    Console.Write($"{multiply_result[i]} ");
                                Console.WriteLine();
                            }
                            break;
                        case 15:
                            if (isSave)
                            {
                                array = array.Where(i => i % 2 != 0).ToArray();
                                Console.WriteLine("Succesfully save!");
                            }
                            else
                            {
                                multiply_result = array.Where(i => i % 2 != 0).ToArray();

                                Console.Write("Result: ");
                                for (int i = 0; i < multiply_result.Length; ++i)
                                    Console.Write($"{multiply_result[i]} ");
                                Console.WriteLine();
                            }
                            break;
                        case 16:
                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i % 2 == 0).Sum();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i % 2 == 0).Sum());
                            }
                            catch
                            {
                                Console.WriteLine("Such numbers doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                        case 17:
                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i % 2 != 0).Sum();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i % 2 != 0).Sum());
                            }
                            catch
                            {
                                Console.WriteLine("Such numbers doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                        case 18:
                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i % 2 != 0).Max();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i % 2 != 0).Max());
                            }
                            catch
                            {
                                Console.WriteLine("Such number doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                        case 19:
                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i % 2 != 0).Min();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i % 2 != 0).Min());
                            }
                            catch
                            {
                                Console.WriteLine("Such number doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                        case 20:
                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i % 2 == 0).Max();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i % 2 == 0).Max());
                            }
                            catch
                            {
                                Console.WriteLine("Such number doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                        case 21:
                            try
                            {
                                if (isSave)
                                {
                                    result = array.Where(i => i % 2 == 0).Min();
                                    Console.WriteLine("Succesfully save!");
                                }
                                else
                                    Console.WriteLine("Result: " + array.Where(i => i % 2 == 0).Min());
                            }
                            catch
                            {
                                Console.WriteLine("Such number doesn't exist in this array.\n" +
                                                  "The array has remained unchanged!\n");
                            }
                            break;
                        case 22:
                            if (isSave)
                            {
                                Array.Reverse(array);
                                Console.WriteLine("Succesfully save!");
                            }
                            else
                            {
                                multiply_result = array.Reverse().ToArray();

                                Console.Write("Result: ");
                                for (int i = 0; i < multiply_result.Length; ++i)
                                    Console.Write($"{multiply_result[i]} ");
                                Console.WriteLine();
                            }
                            break;
                        case 23:
                            if (isSave)
                            {
                                array = array.OrderBy(i => i).ToArray();
                                Console.WriteLine("Succesfully save!");
                            }
                            else
                            {
                                multiply_result = array.OrderBy(i => i).ToArray();

                                Console.Write("Result: ");
                                for (int i = 0; i < multiply_result.Length; ++i)
                                    Console.Write($"{multiply_result[i]} ");
                                Console.WriteLine();
                            }
                            break;
                        case 24:
                            if (isSave)
                            {
                                array = array.OrderByDescending(i => i).ToArray();
                                Console.WriteLine("Succesfully save!");
                            }
                            else
                            {
                                multiply_result = array.OrderByDescending(i => i).ToArray();

                                Console.Write("Result: ");
                                for (int i = 0; i < multiply_result.Length; ++i)
                                    Console.Write($"{multiply_result[i]} ");
                                Console.WriteLine();
                            }
                            break;
                        case 25:
                            Console.Write("\nCurrent state of array:");
                            for (int i = 0; i < array.Length; ++i)
                                Console.Write($"{array[i]} ");
                            Console.WriteLine();
                            break;
                        case 26:
                            Console.WriteLine("\nCurrent state of variable: " + result);
                            break;
                        case 27:
                            Console.WriteLine("\nGood Bye!");
                            Console.WriteLine("Press any key for close the program...");
                            Console.ReadKey();
                            return;
                    }
                }
        
                // input current state of array and variable
                if (action != 25 && action != 26)
                {
                    Console.Write("Current state of array: ");
                    for (int i = 0; i < array.Length; ++i)
                        Console.Write($"{array[i]} ");

                    Console.WriteLine($"\nCurrent state of variable: {result}");
                }

                // an offer to continue a working with this program
                {
                    Console.Write("\nDo you want to continue a work?(y/n)...");
                    char.TryParse(Console.ReadLine(), out char answer);
                    if (answer != 'y' && answer != 'Y')
                    {
                        Console.WriteLine("Good Bye!");
                        Console.Write("Press any key to close the program...");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine();
                }
            } while (true);

        }
    }
}
