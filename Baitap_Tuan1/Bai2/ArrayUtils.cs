using System;

public class ArrayProcessor
{
    private int[] arr;

    public void Input()
    {
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());
        arr = new int[n];

        Console.WriteLine($"Enter {n} integers separated by space:");
        string[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < n; i++)
            arr[i] = int.Parse(values[i]);
    }

    public void Display()
    {
        Console.WriteLine(string.Join(" ", arr));
    }

    public void BubbleSort()
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = n - 1; j > i; j--)
            {
                if (arr[j] < arr[j - 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                }
            }
        }
    }

    public void QuickSort(int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(left, right);
            QuickSort(left, pivotIndex - 1);
            QuickSort(pivotIndex + 1, right);
        }
    }

    private int Partition(int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp2 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp2;

        return i + 1;
    }

    public int LinearSearch(int key)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == key)
                return i;
        }
        return -1;
    }

    public int BinarySearch(int key)
    {
        int left = 0, right = arr.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (arr[mid] == key)
                return mid;
            else if (arr[mid] < key)
                left = mid + 1; 
            else
                right = mid - 1;
        }
        return -1;
    }

    public int[] CloneArray() => (int[])arr.Clone();
    public void SetArray(int[] newArray) => arr = newArray;
    public int Length => arr.Length;
}
