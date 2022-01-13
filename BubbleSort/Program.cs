using System;

namespace BubbleSort
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
            BubbleSort bs = new BubbleSort();
            vs = bs.Sort(vs);
            foreach (var elem in vs)
            {
                Console.WriteLine(elem);
            }
        }
    }

    class BubbleSort
    {
        public int[] Sort(int[] Array)
        {
            return _Sort(Array);
        }
        private int[] _Sort(int[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                bool NoExchange = true;
                for (int j = 0; j < Array.Length - 1 - i; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        var SwapElem = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = SwapElem;
                        NoExchange = false;
                    }
                }
                if (NoExchange)
                {
                    break;
                }
            }
            return Array;
        }
    }
}