using System;

namespace ShellSort
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
            ShellSort bs = new ShellSort();
            vs = bs.Sort(vs);
            foreach (var elem in vs)
            {
                Console.WriteLine(elem);
            }
        }
    }

    class ShellSort 
    {
        public int[] Sort(int[] Array)
        {
            for (int s = (Array.Length - 1) / 2; s > 0; s /= 2)
            {
                for (int i = s; i < (Array.Length - 1); ++i)
                {
                    for (int j = i - s; j >= 0 && Array[j] > Array[j + s]; j -= s)
                    {
                        int temp = Array[j];
                        Array[j] = Array[j + s];
                        Array[j + s] = temp;
                    }
                }
            }

            return Array;
        }
    }
}