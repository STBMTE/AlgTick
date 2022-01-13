using System;

namespace SelectionSort
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
            SelectionSort bs = new SelectionSort();
            vs = bs.Sort(vs);
            foreach (var elem in vs)
            {
                Console.WriteLine(elem);
            }
        }
    }

    class SelectionSort
    {
        public int[] Sort(int[] Array)
        {
            for(int i = 0; i < Array.Length - 1; i++)
            {
                int minId = i + 1;
                for(int j = i; j < Array.Length; j++)
                {
                    if(Array[j] < Array[minId])
                    {
                        minId = j;
                    }
                }
                if (i != minId)
                {
                    var swapElement = Array[minId];
                    Array[minId] = Array[i];
                    Array[i] = swapElement;
                }
            }
            return Array;
        }        
    }
}