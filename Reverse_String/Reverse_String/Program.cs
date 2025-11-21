using System;
using System.Net.NetworkInformation;

namespace Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* string str = "Hello";
             ReverseString(str);

             int[] nums = [1, 2, 4, 5];
             MissingNumber(nums);

             int[] nums = [1, 2, 2, 3, 4, 4, 5];
             Removeduplicate(nums);
            
            int[] nums = [1, 2, 4, 5];
            SecondHighestNo(nums);
            
            FibonacciSeries(6);
          
            Palindrom("nitin");
          
            int[] nums = [1, 2, 4, 5];
            SumIndex(nums);
            
            int[] nums = [1, 2, 4, 5];
            Console.WriteLine("Enter the at a position where you want to insert the elememnt.");
            int Target_Value = Convert.ToInt32(Console.ReadLine());
            SearchInsert(nums, Target_Value);
         
            string s= Console.ReadLine();
            CharCount(s);
            

            string s = Console.ReadLine();
            First_NonReapitingChar(s);
            */
            int[] arr1 = { 1, 2, 3 };
            int[] arr2 = { 1,3, 4 };
            CommonElelement(arr1 , arr2);
        }

        public static void ReverseString(string strArray)
        {
                for(int i= strArray.Length-1;i>=0;i--)
                {
                    Console.Write(strArray[i]);
                }
        }

        public static void MissingNumber(int[] num)
        {
            int arrlen = num.Length+1;
            int sumofarray = 0;
            int result = arrlen * (arrlen + 1) / 2;

            foreach (int i in num)
            {
                sumofarray += i;
            }
            Console.WriteLine($"Missing Number is: {result - sumofarray}");
        }

        public static void Removeduplicate(int[] nums)
        {/*
            //Using HashSet Collection.
            HashSet<int> set = new HashSet<int>();

            foreach (int num in nums)
            {
                set.Add(num);
            }

            foreach(var i  in set)
            {
                Console.WriteLine($"{i}");
            }

            //Using LINQ
            int[] result = arr.Distinct().ToArray();
            foreach(var i  in result)
            {
                Console.WriteLine($"{i}");
            }
            */
            //Without any built in method 
            int resultindex = 0;
            int[] result = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                bool IsDuplicate = false;
                for (int j = 0; j < resultindex; j++)
                {
                    if (nums[i] == result[j])
                    {
                        IsDuplicate = true;
                        break;
                    }

                }
               
                      
                if (!IsDuplicate)
                {
                    result[resultindex] = nums[i];
                    resultindex++;
                }
            }

            int[] finalResult = new int[resultindex];
            for (int i = 0; i < resultindex; i++)
            {
                finalResult[i] = result[i];
                Console.WriteLine(finalResult[i]);
            }

        }

        //Find second highest number in array
        public static void SecondHighestNo(int[] num)
        {
            
            for(int i = 0;i < num.Length;i++)
            {
                for(int j = 0;j < num.Length-1;j++)
                {
                    int temp;
                    temp=num[j];
                    num[j]=num[j+1];
                    num[j+1]=temp;
                }
            }

            Console.WriteLine(num[num.Length - 2]);           
        }
        //Fibonacci Series

        public static void FibonacciSeries(int num)
        {
            int next, a=0, b = 1;
            Console.Write(a + " " + b +" "); 
            for(int i=0; i<=num;i++)
            {
               
                next = a + b;
                Console.Write(next + " ");
                a = b;
                b = next;

                //Console.WriteLine(next);
            }
           
            
        }

        //Palindrome Check

        public static void Palindrom(string str )
        {
            char[] revstr = str.ToCharArray();
            char[] array= new char[revstr.Length];
            int j = 0;
            for(int i= revstr.Length-1; i>=0 ; i--)
            {
                  array[j] = revstr[i];
                j++;
            }
            bool isPalindrome = true;
            for (int i = revstr.Length - 1; i >= 0; i--)
            {
                if (array[i] != revstr[i])
                {
                    isPalindrome = false;
                    break;

                }

            }

            if (isPalindrome)
            {
                Console.WriteLine("It is a palindrome.");
            }
            else
            {
                Console.WriteLine("It is not a palindrome.");
            }
        }
        //Given an integer array and a target value, return indices of two numbers that add up to the target.

        public static void SumIndex(int[] arr)
        {
            Console.WriteLine("Enter the terget Value..");
            int targetvalue = Convert.ToInt32(Console.ReadLine());

            for(int i=0; i<arr.Length; i++)
            {
                for(int j=i+1;j<arr.Length;j++)
                {
                    if ((arr[i] + arr[j] )== targetvalue)
                    {
                        Console.WriteLine($"The Index of the element which addition is : {targetvalue} = {i} {j}");
                    }
                }
            }
        }

        public static void SearchInsert(int[] arr,int TargetValue)
        {
            int Index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] >= TargetValue)
                {
                    Index = i;
                    break;   
                }
                if(i==arr.Length-1)
                {
                    Index = arr.Length;

                }
            }
            Console.WriteLine($"you can insert element at : {Index}");

        }

        public static void CharCount(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else
                {
                    dic[c] = 1;
                }
            }

            foreach(var c in dic)
            {
                Console.WriteLine($"{c.Key} ==> {c.Value}");
            }
        }
        public static void  First_NonReapitingChar(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else
                {
                    dic[c] = 1;
                }
            }
            
            foreach( char c in s)
                if (dic[c] ==1)
                {
                    Console.WriteLine(c);
                }
            
        }

        public static void CommonElelement(int[] arr1, int[] arr2)

        {
           
         #region Using Without any built in method...
            /*
            int[] arr3 = new int[arr1.Length];
            int index = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        arr3[index] = arr1[i];
                        index++;
                    }
                }

            }
            for (int i = 0; i <index; ++i)
            {
                Console.Write(arr3[i] + " ");
            }
            */
            #endregion

            #region With LINQ
            /*
            var result = arr1.Intersect(arr2);
            foreach(var c in result)
            {
                Console.WriteLine(c);
            }
            */
            #endregion
            #region with Collection

            HashSet<int> set = new HashSet<int>(arr2);
            List<int> list = new List<int>();

            foreach(var c in arr1)
            {
                if(set.Contains(c))
                {
                    list.Add(c);
                }
            }

            foreach(var c in list)
            {
                Console.WriteLine(c);
            }
            #endregion
        }
    }

  
}
