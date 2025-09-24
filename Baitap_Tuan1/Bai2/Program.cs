using System;

class Program
{
    static void Main()
    {
        ArrayProcessor processor = new ArrayProcessor();
        processor.Input();

        Console.WriteLine("\nOriginal array:");
        processor.Display();
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Choose algorithm:");
            Console.WriteLine("1.Buble Sort");
            Console.WriteLine("2.Quick Sort");
            Console.WriteLine("3.Linear Search");
            Console.WriteLine("4.Binary Search");
            Console.WriteLine("5.Exit");
            Console.Write("Enter your choice (1-5): ");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                int[] bubbleSorted = processor.CloneArray();
                processor.BubbleSort();
                Console.Write("\nArray after Bubble Sort:");
                processor.Display();
                processor.SetArray(bubbleSorted);
            }
            else if (choice == 2)
            {
                int[] quickSorted = processor.CloneArray();
                processor.QuickSort(0, processor.Length - 1);
                Console.Write("\nArray after Quick Sort:");
                processor.Display();
                processor.SetArray(quickSorted);
            }
            else if (choice == 3)
            {
                Console.Write("\nEnter a number to search (linear search): ");
                int key = int.Parse(Console.ReadLine());

                int indexLinear = processor.LinearSearch(key);
                Console.WriteLine(indexLinear != -1
                    ? $"Linear Search: Found {key} at index {indexLinear}"
                    : $"Linear Search: {key} not found.");
            }
            else if (choice == 4)
            {
                processor.QuickSort(0, processor.Length - 1);
                Console.Write("\nEnter a number to search (binary search): ");
                int key = int.Parse(Console.ReadLine());
                
                int indexBinary = processor.BinarySearch(key);
                Console.WriteLine(indexBinary != -1
                    ? $"Binary Search: Found {key} at index {indexBinary}"
                    : $"Binary Search: {key} not found.");
            }
            else if (choice == 5)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a number between 1 and 5.");
            }
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
