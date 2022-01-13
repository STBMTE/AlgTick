using System;

namespace InsertionSort
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
            InsertionSort bs = new InsertionSort();
            vs = bs.Sort(vs);
            foreach (var elem in vs)
            {
                Console.WriteLine(elem);
            }
        }
    }

    class InsertionSort
    {
        public int[] Sort(int[] Array)
        {
            for (int i = 1; i < Array.Length; i++)
            {
                for (int j = i; j > 0 && Array[j - 1] > Array[j]; j--)    
                {                             
                    var tmp = Array[j];            
                    Array[j] = Array[j - 1];        
                    Array[j - 1] = tmp;
                }
            }
            return Array;
        }
    }
}