using Delegates1;
namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkPerformHandler del1 = new WorkPerformHandler(Worker_WorkPerformed);
            WorkCompaleteHandler del2 = new WorkCompaleteHandler(Worker_WorkCompleted);
            Delegates12 worker = new Delegates12();
            worker.Work(5, "Generating Report", del1, del2);
            Console.ReadKey();
        }
        static void Worker_WorkPerformed(int hours, string workType)
        {
            Console.WriteLine($"{hours} Hours compelted for {workType}");
        }
        static void Worker_WorkCompleted(string workType)
        {
            Console.WriteLine($"{workType} work compelted");
        }
    }
}
