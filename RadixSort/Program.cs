using System;

namespace RadixSort
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
            RadixSort bs = new RadixSort();
            vs = bs.Sort(vs);
            foreach (var elem in vs)
            {
                Console.WriteLine(elem);
            }
        }
    }

    class RadixSort
    {
        public int[] Sort(int[] arr)
        {
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = sizeof(int) * 8 - 1; shift >= 0; shift--)
            {
                j = 0;
                for (i = 0; i < arr.Length; i++)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }
            return tmp;
        }
    }
}
