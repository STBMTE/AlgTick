using System;

namespace ABCSort
{
    class Program
    {
        public static void Main()
        {
            Random random = new Random();
            string s = "we can’t use counting sort because counting sort will take o(n2) which is worse than comparison-based sorting algorithms. Can we sort such an array in linear time? ";
            string[] vs = s.Split();
            ABCSort bs = new ABCSort();
            vs = bs.Sort(vs, 0);
            foreach (var elem in vs)
            {
                Console.WriteLine(elem);
            }
        }
    }

    class ABCSort
    {
        public string[] Sort(string[] Array, int rank)
        {
            if (Array.Length <= 1)
            {
                return Array;
            }
            var square = new Dictionary<char, List<string>>(62);
            var result = new List<string>();
            int shortWordsCounter = 0;
            foreach (var word in Array)
            {
                if (rank < word.Length)
                {
                    if (square.ContainsKey(word[rank]))
                    {
                        square[word[rank]].Add(word);
                    }
                    else
                    {
                        square.Add(word[rank], new List<string> { word });
                    }
                }
                else
                {
                    result.Add(word);
                    shortWordsCounter++;
                }
            }

            if (shortWordsCounter == Array.Length)
            {
                return Array;
            }
            for (char i = 'A'; i <= 'z'; i++)
            {
                if (square.ContainsKey(i))
                {
                    foreach (var word in Sort(square[i].ToArray(), rank + 1))
                    {
                        result.Add(word);

                    }
                }
            }
            return result.ToArray();
        }

    }
}