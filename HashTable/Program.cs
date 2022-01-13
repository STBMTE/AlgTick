using System;

namespace HashTable
{
    class Program
    {
        public static void Main()
        {
            Random random = new Random();
            int[] vs = new int[10];
            HashTable bs = new HashTable(10);
            for(int i = 1; i <= 10; i++)
            {
                bs.Add(i, i * 3);
            }
            /*Console.WriteLine(bs.Search(10));*/
            bs.Remove(5);
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine(bs.Search(i));
            }
        }
    }

    class Item
    {
        public Item(int key, int value)
        {
            Key = key;
            Value = value;
        }
        public int Key { get; set; }
        public int Value { get; set; }
    }

    class HashTableChainMethod
    {
        List<Item>[] Items { get; set; }

        public HashTableChainMethod(int length)
        {
            Items = new List<Item>[length];
        }

        public void Add(int key, int value)
        {
            int hKey = HashFunction(key);
            if (Items[hKey] == null)
            {
                Items[hKey] = new List<Item>();
            }
            Items[hKey].Add(new Item(key, value));
        }

        public int HashFunction(int key)
        {
            return key % Items.Length;
        }

        public void Remove(int key)
        {
            int hKey = HashFunction(key);
            List<Item> chain = Items[hKey];
            Item elem = new Item(0, 0);
            foreach (Item item in chain)
            {
                if (item.Key == key)
                {
                    elem = item;
                    break;
                }
            }
            Items[hKey].Remove(elem);
        }

        public int Search(int key)
        {
            int hKey = HashFunction(key);
            var chain = Items[hKey];
            foreach(Item item in chain)
            {
                if(item.Key == key)
                {
                    return item.Value;
                }
            }
            return int.MinValue;
        }
    }

    class HashTable
    {
        Item[] Data { get; set; }

        public void Add(int key, int value)
        {
            int i = 0;
            int j = HashFunction(key);
            while(Data[j] != null)
            {
                i = i + 1;
                j = HashFunction(key, i);
            }
            Data[j] = new Item(key, value);
        }

        public HashTable(int Length)
        {
            Data = new Item[Length];
        }

        public void Remove(int key)
        {
            int i = 0;
            int j = HashFunction(key);
            while (Data[j].Key != key)
            {
                i = i + 1;
                j = HashFunction(key, i);
            }
            Data[j] = null;
        }

        public int Search(int key)
        {
            int i = 0;
            int j = HashFunction(key);
            while(i < Data.Length)
            {
                i = i + 1;
                j = HashFunction(key, i);
                if (Data[j] != null)
                {
                    if (Data[j].Key == key)
                    {
                        break;
                    }
                }
            }
            if (Data[j] == null)
            {
                return int.MinValue;
            }
            return Data[j].Value;
        }

        private int HashFunction(int key, int dependenci = 0)
        {
            return Math.Abs(key + (dependenci * key)) % Data.Length;
        }
    }
}