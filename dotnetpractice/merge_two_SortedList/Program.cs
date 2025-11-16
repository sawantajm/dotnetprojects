namespace merge_two_SortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> List1 = new List<int> { 1, 2, 4 };
            List<int> List2 = new List<int> { 1, 3, 4 };

            List<int> ResultList = new List<int>();

            foreach (int i in List1)
            {
                ResultList.Add(i);
            }

            foreach (int i in List2)
            {
                ResultList.Add(i);
            }

            foreach (int i in ResultList)
            {
                Console.WriteLine(i);
            }
        }
    }
}
