namespace Palindrome_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program program = new Program();
            bool value = program.IsPalindrom(10);
            Console.WriteLine(value);
        }

         public bool IsPalindrom(int x)
        {
            if (x < 0)
            {
                return false;
            }
            int[] array = x.ToString().Select(c => int.Parse(c.ToString())).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != array[array.Length - 1 - i])
                {
                    return false;
                }

            }
            return true;
        }
    }
}
