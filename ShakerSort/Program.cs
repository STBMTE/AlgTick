using System;

namespace ShakerSort
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
            ShakerSort bs = new ShakerSort();
            vs = bs.Sort(vs);
            foreach (var elem in vs)
            {
                Console.WriteLine(elem);
            }
        }
    }

    class ShakerSort
    {
        private void Swap(ref int a, ref int b)
        {
            int z = a;
            a = b;
            b = z;
        }

        public int[] Sort(int[] Array)
        {
            for(int i = 0; i < Array.Length; i++)
            {
                bool UnSwaped = true;
                for (int j = i; j < Array.Length - 1 - i; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        Swap(ref Array[j], ref Array[j + 1]);
                        UnSwaped = false;
                    }
                }
                for(int j = Array.Length - 1 - i; j > i; j--)
                {
                    if (Array[j] < Array[j - 1])
                    {
                        Swap(ref Array[j], ref Array[j - 1]);
                        UnSwaped = false;
                    }
                }
                if (UnSwaped)
                {
                    break;
                }
            }
            return Array;
        }
    }
}