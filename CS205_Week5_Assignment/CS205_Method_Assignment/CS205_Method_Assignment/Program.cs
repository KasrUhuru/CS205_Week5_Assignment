using System;
using System.IO;
using System.Diagnostics;

namespace CSC205Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "numbers.txt";
            Stopwatch stopwatch = new Stopwatch();

            // Generate random numbers and write them to the file
            Method01(fileName, 1000, 1, 1001);

            // Read all lines from the file into a string array
            string[] lines = File.ReadAllLines(fileName);
            int[] values = new int[lines.Length];

            // Convert each line from a string to an integer and store in the values array
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Convert.ToInt32(lines[i]);
            }

            stopwatch.Start();
            Console.WriteLine("starting ... ");

            // Sort the array using selection sort
            Method02(values);
            Console.WriteLine("done! ... ");

            stopwatch.Stop();
            Console.WriteLine("time measured: {0} ms", stopwatch.ElapsedMilliseconds);

            // Print the sorted values
            foreach (int value in values)
                Console.Write(value + " ");
            Console.WriteLine();
        }

        static void Method01(string fileName, int total, int lowerRange, int upperRange)
        {
            // Open the specified file for writing
            using (var writer = new StreamWriter(fileName))
            {
                Random r = new Random(); // Create a new instance of Random to generate random numbers
                int number = 0;
                {
                    // Loop to generate 'total' random numbers
                    for (int i = 1; i < total; i++)
                    {
                        number = r.Next(lowerRange, upperRange); // Generate a random number within the specified range
                        writer.WriteLine(number); // Write the generated number to the file
                    }
                }
            }
        }

        static void Method02(int[] arr)
        {
            // Loop through each element of the array (except the last one)
            for (int start = 0; start < arr.Length - 1; start++)
            {
                int posMin = start; // Assume the current position is the minimum

                // Loop to find the minimum element in the unsorted part of the array
                for (int i = start + 1; i < arr.Length; i++)
                {
                    // Update posMin if a smaller element is found
                    if (arr[i] < arr[posMin])
                    {
                        posMin = i;
                    }
                }

                // Swap the found minimum element with the first element of the unsorted part
                int tmp = arr[start];
                arr[start] = arr[posMin];
                arr[posMin] = tmp;
            }
        }
    }
}
