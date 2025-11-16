using System.Collections.Generic;

namespace GenericCollection
{
     class Program
    {
        static void Main(string[] args)
        {
            //List
            List<int> list = new List<int>();
            list.Add(1);                             //Add element in List
            list.Add(6);
            list.Add(5);
            list.Add(4);
            Console.WriteLine("\nList of Elements of List Collection");
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nList of Elements of Sorted List Collection");
            list.Sort();
            foreach (var i in list)
            {
                Console.WriteLine($"{i}");
            }
            // HashSet 
            HashSet<int> set = new HashSet<int>();
            set.Add(11);
            set.Add(22);
            set.Add(55);
            set.Add(65);
            set.Add(65);
            Console.WriteLine("\nList of Elements of HashSet Collection");
            foreach (var i in set)
            {
                Console.WriteLine($"{i}");
            }

            //Sorted Set

            SortedSet<int> sortedset = new SortedSet<int>();
            sortedset.Add(11);
            sortedset.Add(10);
            sortedset.Add(13);
            sortedset.Add(12);                 // Add element in Sorted set
            sortedset.Add(12);
            Console.WriteLine("\nList of Elements of SortedSet:");
            foreach (var i in sortedset)
            {
                Console.WriteLine($"{i}");
            }
            Console.WriteLine("\nRemove Element from SortedSet:");
            foreach (var i in sortedset)
            {
                Console.WriteLine($"{i}");
            }
            sortedset.Remove(11);

            //Stack<T>
            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(12);
            stack.Push(14);
            stack.Push(13);
            stack.Push(11);

            Console.WriteLine("\nList of Element of Stack ");

            foreach(var item in stack)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("\nPOP Element from Stack");
            stack.Pop();
            foreach (var item in stack)
            {
                Console.WriteLine($"{item}");

            }
                //Queue<T>

             Queue<string> ListofElements = new Queue<string>();
             ListofElements.Enqueue("India");
             ListofElements.Enqueue("UK");
             ListofElements.Enqueue("North America");
             ListofElements.Enqueue("Germany");
             ListofElements.Enqueue("China");
             Console.WriteLine("\nList of Element of Queue");
             foreach(var item in ListofElements)
             {
             Console.WriteLine($"{item}");
             }

            Console.WriteLine("\nList of Element of Queue after Dqueue");
            ListofElements.Dequeue();
            foreach(var item in ListofElements )
            {
                Console.WriteLine($"{item}");
            }

            //Dictonary<Tkey, TValue>

            Dictionary<string, string> City = new Dictionary<string, string>();
            City.Add("10135","North America");
            City.Add("13609", "China Operation");
            City.Add("10090", "Germany");
            City.Add("10132", "China");
            City.Add("10188", "Itali");
            Console.WriteLine("\nList of Element of Dictionary");
            foreach(var item in City)
            {
                Console.WriteLine($"{item}");
            }

            SortedDictionary<string, string> SortedCity = new SortedDictionary<string, string>();
            SortedCity.Add("10135", "North America");
            SortedCity.Add("13609", "China Operation");
            SortedCity.Add("10090", "Germany");
            SortedCity.Add("10132", "China");
            SortedCity.Add("10188", "Itali");
            Console.WriteLine("\nList of Element of SortedDictionary");
            foreach (var item in SortedCity)
            {
                Console.WriteLine($"{item}");
            }

            //SortedList<Tkey, Tvalue>

            SortedList<int, string> sortedlist = new SortedList<int, string>();
            sortedlist.Add(1, "Ajay");
            sortedlist.Add(3, "Kedar");
            sortedlist.Add(9, "Nitin");
            sortedlist.Add(4, "Akash");
            Console.WriteLine("\nList of Element of SortedList");
            foreach (KeyValuePair<int, string>  item in sortedlist)
            {
                Console.WriteLine($"Key: {item.Key} Value: {item.Value}");
            }
            Console.ReadKey();

        }
    }
}
