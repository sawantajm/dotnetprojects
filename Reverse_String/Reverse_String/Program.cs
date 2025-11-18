using System;
using System.Net.NetworkInformation;

namespace Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string str = "Hello";
            //ReverseString(str);

            //int[] nums = [1, 2, 4, 5];
            //MissingNumber(nums);

            int[] nums = [1, 2, 2, 3, 4, 4, 5];
            Removeduplicate(nums);
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
    }
}
