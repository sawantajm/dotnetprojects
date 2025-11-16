lusing INTERFACES;
namespace INTERFACES
{
     class Program :Itest1
    {

        public void Add(int a, int b)
        {
            int result = 0;
            result = a + b;
        }

        public void sub(int a,int b)
        {
            int result = 0;
            result = a - b;
            Console.WriteLine($"The value of {result}");
        }
        static void Main(string[] args)
        {
            Program Pr = new Program();
            Pr.Add(10,20);
            Pr.sub(30,40);
        }


    }

}
