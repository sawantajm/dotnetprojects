using System.Collections;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            String test = "Test Capital String";
            string Test = "Small String";
            Console.WriteLine($"{test} \t {Test}");

            object obj = null;
            //string tostring = obj.ToString();
            //Console.WriteLine($"{tostring}");
            string s = Convert.ToString(obj);
            Console.WriteLine($"{s}");

            TestCollection testCollection = new TestCollection();
            testCollection.Add();


        }
    }

    class TestCollection
    {
        ArrayList Alist = new ArrayList();
        public void Add()
        {
            
            Alist.Add(1);
            foreach (int i in Alist)
            {
                Console.WriteLine(i);
            }

            
        }
       
       

        

    }
}
