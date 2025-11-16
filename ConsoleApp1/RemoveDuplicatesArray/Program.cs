namespace RemoveDuplicatesArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1,3,4,5,6,7,81,2,3,4};
            int[] dup = arr.Distinct().ToArray();
            `
            foreach(int x in dup)
            {
                Console.WriteLine(x);
            }
            //HashSet<int> hash = new HashSet<int>();
            //foreach (var i in arr)
            //{
            //    hash.Add(i);
            //}
            //foreach (var item in hash)
            //{
            //    Console.WriteLine(item);
            //}
            //for (int i=0; i<arr.Length;i++)
            //{
            //    for(int j=0; j<arr.Length-1;j++)
            //    {
            //        if(arr[i] != arr[j + 1] )
            //        {
            //            hash.Add(arr[i]);
            //        }
            //    }
            //}
            //foreach(var i in hash)
            //{
            //    Console.WriteLine($"{i}");
            //}
        }
    }
}
