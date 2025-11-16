namespace LINQ_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> IntegerList = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10
            };

            //Example Using LINQ Query Syntax in C#:
            var querySysntax = from obj in IntegerList
                               where obj > 5
                               select obj;

            Console.WriteLine($"Using LINQ Query Syntax in C#:");
            foreach(var item in querySysntax)
            {
                Console.WriteLine(item +"  " );
            }

            //Example Using LINQ Method Syntax in C#:

            var MethodSyntax = IntegerList.Where(x => x > 5);

            Console.WriteLine($"\n Using LINQ Method Syntax in C#:");
            foreach (var i in MethodSyntax)
            {
                Console.WriteLine($"{i}" + " ");
            }


            //Example Using LINQ Mixed Syntax in C#:


            var MixedSyntax = (from obj in IntegerList
                               where obj > 5
                               select obj).Sum();

            Console.WriteLine($" \n Example Using LINQ Mixed Syntax in C#: " + MixedSyntax);

        }
    }
}
