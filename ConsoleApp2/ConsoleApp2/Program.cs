using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringLength
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string");
            string a = Console.ReadLine();
            //Find lenght of String
            /*int len = 0;
            foreach(char  i in a)
            {
                len++;
            }
            
            Console.WriteLine(len);*/

            /*
            // separate individual characters from a string
            char str;
            for(int i = 0;i<a.Length;i++)
            {
               Console.Write(a[i] + " ");
            }
          
          
             // string in reverse order
            Console.Write("The characters of the string in reverse are:\n");
            for (int i = a.Length-1; i>=0; i--)
            {
                Console.Write(a[i] +" ");
            }
             */

            /*
             // total number of words in a string
            int count = 1;

            for(int i=0; i<a.Length; i++) {

                if(a[i]==' ')
                {
                    count++;
                }
                
              
            }
            Console.WriteLine(count);
            */

            /*
             //compare two strings without using a string library functions
            Console.WriteLine("Enter the second String");
            string b = Console.ReadLine();

            if (a==b) {
                Console.WriteLine("Both strigs are equals");

            }
            */

            /*
             // count the number of alphabets, digits and special characters in a string
            int alph=0, specialchar=0, digit=0;
            
            for(int i=0;i< a.Length;i++)
            {
                if ((a[i] >= 'A' &&  a[i] <='Z') || (a[i] >='a' && a[i]<='z'))
                {
                    alph++;
                }

                else if (a[i] >= '0'&& a[i]<= '9')
                {
                    digit++;
                }
                else
                {
                    specialchar++;
                }
                
            }
            Console.WriteLine($"alphabets counts are :{alph}");
            Console.WriteLine($"Digit count : {digit}");
            Console.WriteLine($"special character count :{specialchar}");
            */
            /* //find the maximum number of characters in a string
            char maxchar = ' ';
            int maxcount = 0;
            foreach (char c in a)
            {
                int count = 0;
                foreach (char c2 in a)
                {
                    if (c == c2)
                    {
                        count++;
                    }
                }

                if(count >maxcount)
                {
                    maxcount = count;
                    maxchar = c;
                }

                
            }
            Console.WriteLine(maxchar + ":" + maxcount);
            */


            //char[] charr = a.ToCharArray();

            //for (int i = 0; i < a.Length; i++)
            //{
            //    for (int j = 0; j < a.Length - i - 1; j++)
            //    {


            //        if (charr[j] > charr[j + 1])
            //        {
            //            // Swap
            //            char temp = charr[j];
            //            charr[j] = charr[j + 1];
            //            charr[j + 1] = temp;
            //        }

            //    }

            //}
            //Console.WriteLine(charr);

            //string[] abc =a.Split(' ');
            //Array.Reverse(abc);

            



        }
    }
}