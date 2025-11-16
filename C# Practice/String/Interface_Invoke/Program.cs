namespace Interface_Invoke
{

    public class TestInterface : ITest
    {
        
        
        
        public void TESTInterfacedotnet9()
        {
            Console.WriteLine("Menthod 9 Implemented");
        }
       //public void TESTInterfacedotnet8()
       // {
       //     Console.WriteLine("TestInterface");

       // }

    }
    public  class Program
    {
        static void Main(string[] args)
        {
            TestInterface  testInterface = new TestInterface();
            ITest test = new TestInterface();
            testInterface.TESTInterfacedotnet9();
            test.TESTInterfacedotnet8();


        }
}
}
