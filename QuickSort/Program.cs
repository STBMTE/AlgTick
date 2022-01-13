using System;

namespace QuickSort
{
    class Program
    {
        public static void Main()
        {
            Random random = new Random();
            int[] vs = new int[10];
            for (int i = 0; i < 10; i++)
            {
                vs[i] = random.Next();
            }
            QuickSort bs = new QuickSort();
            bs.Sort(ref vs);
            foreach (var elem in vs)
            {
                Console.WriteLine(elem);
            }
        }
    }

    class QuickSort
    {
        public void Sort(ref int[] Array)
        {
            quicksort(ref Array, 0, Array.Length - 1);
        }
        private int partition(ref int[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    int temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        private void quicksort(ref int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(ref array, start, end);
            quicksort(ref array, start, pivot - 1);
            quicksort(ref array, pivot + 1, end);
        }

    }
}