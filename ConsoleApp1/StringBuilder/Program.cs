using System;
using System.Text;
namespace StringBuilder1
{
     class Program
    {
        
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine("Append string in String builder");
            stringBuilder.Append("DotNet Tutorials");
            stringBuilder.Append("  By Ajinath");
            Console.WriteLine(stringBuilder);
            var getstring="";
            for (int i = 0; i < stringBuilder.Length; i++)
            {
               
                 getstring = stringBuilder.ToString();
               
            }
            Console.WriteLine("Review string from the stringBuilder");
            Console.WriteLine(getstring);




        }
    }
}
