using System;

namespace BinarySearch
{
    class Program
    {
        public static void Main()
        {
            Random random = new Random();
            int[] vs = new int[100];
            for (int i = 0; i < 100; i++)
            {
                vs[i] = i * 3;
            }
            BinarySearch bs = new BinarySearch();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(bs.Search(vs, vs[i]));
            }
            
        }
    }

    class BinarySearch
    {
        public int Search(int[] Array, int SearchedNumber)
        {
            int length = Array.Length / 2;
            int lengthStep = Array.Length / 2;
            for(int i = 0; i < Array.Length; i++)
            {
                if(lengthStep < 2)
                {
                    lengthStep = 2;
                }
                if (Array[length] == SearchedNumber)
                {   
                    return length;
                }
                if(Array[length] < SearchedNumber)
                {
                    lengthStep /= 2;
                    length += lengthStep;
                }
                if(Array[length] > SearchedNumber)
                {
                    lengthStep /= 2;
                    length -= lengthStep;
                }
            }
            return -1;
        }
    }
}