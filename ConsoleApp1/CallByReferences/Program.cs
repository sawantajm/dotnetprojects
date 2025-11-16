namespace CallByReferences
{
     class Program
    {
        
            public void show(ref int val)
        {
            val*= val;
            Console.WriteLine("Value inside the show function" + val);
        }
        static void Main()
        {
            int val = 50;
            Program P = new Program();
            Console.WriteLine("Before the Call by Ref value" + val);
            P.show(ref val);
            Console.WriteLine("After Call By Refrence value" + val);

        }
        
    }
}
