using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringLength
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter the string");
            //string a = Console.ReadLine();
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
           */
            /*
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

            /* //Sort the string
              char[] charr = a.ToCharArray();

             for (int i = 0; i < a.Length; i++)
             {
                 for (int j = 0; j < a.Length - i - 1; j++)
                 {


                     if (charr[j] > charr[j + 1])
                     {
                         // Swap
                         char temp = charr[j];
                         charr[j] = charr[j + 1];
                         charr[j + 1] = temp;
                     }

                 }

             }
             Console.WriteLine(charr);
              */

            /*  extract a substring from a given string without using the library function.
             *  
            Console.WriteLine("Enter the position to start extraction");
            int startextraction = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the position to End extraction");
            int ENDextraction = Convert.ToInt32(Console.ReadLine());
            int c = 0;
            char result=' ';
            for (int i= startextraction;i<( ENDextraction + startextraction ); i++ )
            {
                result = a[i];
                Console.Write(result);
            }
            */

            /* check whether a given substring is present in the given string
            Console.WriteLine("Enter the text which you want to findout in string");
            string Searchstring = Convert.ToString(Console.ReadLine());
            if(a.Contains(Searchstring))
            {
                Console.WriteLine("The substring exists in the string");
            }

          */
            /* search for the position of a substring within a string
            Console.WriteLine("Input a substring to be found in the string");
            string b = Console.ReadLine();

            string[] text = a.Split(' ');

            if (text.Length > 0) 
            {
                for (int i = 0; i < text.Length; i++) 
                {
                    if (text[i]==b)
                    {
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine($"{text[i]} in this a string at position: {i}");
                    }
                }
               
            }
            */
            //Console.WriteLine("Input a substring to be found in the string");
            //string b = Console.ReadLine();

            //int at= a.IndexOf(b);

            //int count = 0;
            //    if (a.Length > 0)
            //    {

            //        for (int i = 0; i < a.Length; i++)
            //        {
            //            if (a[i] != ' ')
            //            {
            //                count++;

            //            }
            //        }


            //        Console.WriteLine("-------------------------------------");
            //        Console.WriteLine($"The string '{b}' occurs {count} times");

            //    }

            /*
                // Declare variables to store user input and count occurrences
                string str1;
                string findstring;
                int strt = 0; 
                int cnt = -1; 
                int idx = -1;  
                Console.Write("Input the string to be searched for : ");
                findstring = Console.ReadLine(); 
                while (strt != -1)
                {
                  strt = a.IndexOf(findstring, idx + 1);
                    cnt += 1;
                    idx = strt;
                }


                Console.Write("The string '{0}' occurs " + cnt + " times.\n", findstring);
            */

            /*//Sort string array
string[] array = { "1", "2", "4", "8", "6" };

for (int i = 0; i < array.Length;i++)
{
  for(int j=0;j<array.Length-1;j++)
  {
      string temp;

          if (int.Parse(array[j]) > int.Parse(array[j + 1]))
      {
          temp= array[j+1];
          array[j + 1] = array[j];
          array[j] =temp;

      }
  }

}
for (int i = 0; i < array.Length; i++)
{
  Console.Write(array[i] +" " );
}

//reverse the sentence 
string input = " I am a Ajinath Sawant";
string word="";
string result="";
for (int i = input.Length-1; i >= 0; i--)
{
  if (input[i] != ' ')
  {
      word = input[i] + word; // build word from right to left
  }
  else
  {
      result += word + " ";
      word = "";
  }
}

Console.Write(result);


//String is palindrome or not

string name = Console.ReadLine();
char[] issame = name.ToCharArray();
char[] newstring = new char[issame.Length];
bool ispalindrome = true;
for (int i = 0; i < issame.Length; i++)
{
    newstring[i] = issame[issame.Length - 1 - i];
}
for (int i = 0; i < issame.Length; i++)
{
    if (issame[i] != newstring[i])
    {
        ispalindrome = false;
        break;

    }
}

if (ispalindrome)
{
    Console.WriteLine("it is a palindrom");
}

else
{
    Console.WriteLine("It is not a palindrome");
}



          //sorted in asceding order

          string[] input = {"a","c","b","e","d" };


          for(int i=0; i<input.Length;i++)
          {
              for(int j=0; j<input.Length-1;j++)
              {
                  if (input[j][0] > input[j + 1][0])
                  {
                      string temp = input[j];
                      input[j] = input[j + 1];
                      input[j + 1] = temp;
                  }
              }

          }

          for (int i = 0; i < input.Length; i++)
          {
              Console.Write(input[i] +" ");
          }
          */


            //Count pair with diff value equal K = 2 with O(n2) complexity.
            int[] arr = { 3, 2, 1, 5, 4 ,6};
            //List<int> list = new List<int>();
            //int k = 2;
            //int count = 0;
            //for(int i=0;i<arr.Length;i++)
            //{
            //    for(int j=0;j<arr.Length-1;j++)
            //    {
            //        if (arr[i] - arr[j]==k)
            //        {
            //            count++;
            //            list.Add(arr[j]);
            //        }
            //    }
            //}
            //Console.WriteLine($"The count of diffrence value is: {count}");
            //foreach(int i in list) 
            //    {
            //    Console.WriteLine(i);
            //    }

            //Count pair with diff value equal K = 2 with O(n) complexity.
            HashSet<int> set = new HashSet<int>(arr);
            int count = 0;
            int k = 2;
            foreach (int i in set)
            {
                if(set.Contains(i+k))
                {
                    count++;
                }

                if(set.Contains(i-k))
                {
                    count++;
                }
            }

            Console.WriteLine($"Count {count} of pairs with diffrence {k} : {count / 2}");



        }
    }
}