using System.Collections;

namespace CollectionsinC_
{
    public class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            al.Add(100);
            al.Add(200);
            al.Add(300);

            foreach(var item in al)
            {
                Console.WriteLine(item);
            }
            //Remove Element from array List
            Console.WriteLine("Removing Element from the arrayList");
            al.Remove(100);
            foreach (var item in al)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Removing Element using index");
            al.RemoveAt(0);
            foreach (var item in al)
            {
                Console.WriteLine(item);
            }

        }


        
    }
}
