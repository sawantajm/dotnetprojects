namespace practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*   //Sort string array
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
      }  */

            //rec=verse the sentence 
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


        /*  //String is palindrome or not

          string name = Console.ReadLine(); 
          char[] issame = name.ToCharArray();
          char[] newstring = new char[issame.Length];
          bool ispalindrome = false; 
          for(int i= 0; i< issame.Length; i++)
          {
              newstring[i] = issame[issame.Length - 1-i];
          }
         for(int i= 0;i<issame.Length;i++)
          {
              if (issame[i]== newstring[i])
              {
                  ispalindrome = true ;
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
          } */
        }
    }
    }
