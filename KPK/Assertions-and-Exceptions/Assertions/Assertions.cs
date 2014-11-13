using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public class Assertions
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        var index = BinarySearch(arr, value, 0, arr.Length - 1);

        Debug.Assert(
            index == -1 || arr[index].Equals(value),
            "The element at the returned index was not the same as the searched element");

        return index;
    }

    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array
     
        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
     where T : IComparable<T>
    {
        Debug.Assert(startIndex <= endIndex, "Start index is bigger than end index");
        Debug.Assert(endIndex < arr.Length, "End index is bigger than arr length");
        Debug.Assert(startIndex >= 0, "Start index is less than 0");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(!arr.Where((e, index) => e.CompareTo(arr[minElementIndex]) < 0 && index > startIndex && index <= endIndex).Any(), "Incorreect min element");
        return minElementIndex;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(startIndex <= endIndex, "Start index is bigger than end index");
        Debug.Assert(endIndex < arr.Length, "End index is bigger than arr length");
        Debug.Assert(startIndex >= 0, "Start index is less than 0");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }
}
