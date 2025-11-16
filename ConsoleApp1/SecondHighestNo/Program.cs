using System.Collections.Immutable;

namespace SecondHighestNo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 43, 65, 77, 45, 23 };
             
            
           
            var a = (from i in numbers where i < (from j in numbers where j < (from k in numbers select k).Max() select j ).Max() select i).Max();
             
            //foreach (var i in a)
            //{
               
                Console.WriteLine(a);
            //}

             
        }
    }
}
