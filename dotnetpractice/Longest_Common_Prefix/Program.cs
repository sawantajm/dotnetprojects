using System.Runtime.InteropServices;

namespace Longest_Common_Prefix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] str = ["flower", "flow", "flight"];
          
          string a = LongestCommonPrefix(str);
            Console.WriteLine(a);
            string b =LongestCommon_Prefix(str);
            Console.WriteLine(b);
        }

        static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";

            // Take the first string as a reference
            string first = strs[0];

            for (int i = 0; i < first.Length; i++)
            {
                char c = first[i]; // Current character to compare

                // Compare this character with all other strings
                for (int j = 1; j < strs.Length; j++)
                {
                    // If index exceeds or character mismatch, return prefix found so far
                    if (i >= strs[j].Length || strs[j][i] != c)
                    {
                        // Build prefix manually
                        string result = "";
                        for (int k = 0; k < i; k++)
                            result += first[k];
                        return result;
                    }
                }
            }

            return first;
        }

        static string LongestCommon_Prefix(string[] arr)
        {

            // Sort the array of strings
            Array.Sort(arr);

            // Get the first and last strings after sorting
            string first = arr[0];
            string last = arr[arr.Length - 1];
            int minLength = Math.Min(first.Length,last.Length);

            int i = 0;
            // Find the common prefix between the first and 
            // last strings
            while (i < minLength && first[i] == last[i])
            {
                i++;
            }

            // Return the common prefix
            return first.Substring(0, i);
        }
    }
}
