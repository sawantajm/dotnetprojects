using System.Net.Mime;

namespace dotnetpractice
{
    public class Program
    {
       public  static void Main(string[] args)
        {
            int[] nums1 = [1, 2];
            int[] nums2 = [3, 4];
            double ans = 0;
            Program program = new Program();
            ans=program.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine(ans);
        }

       
            public double FindMedianSortedArrays(int[] nums1, int[] nums2)
            {
                int[] result = new int[nums1.Length + nums2.Length];
                int j = 0;
                double median = 0.0;
                int mid1, mid2;
                for (int i = 0; i < nums1.Length; i++)
                {
                    result[j] = nums1[i];
                    j++;
                }

                for (int i = 0; i < nums2.Length; i++)
                {
                    result[j] = nums2[i];
                j++;
                   
                }

            for (int i = 0; i < result.Length - 1; i++)
            {
                for (int k = 0; k < result.Length - i - 1; k++)
                {
                    if (result[k] > result[k + 1])
                    {
                        int temp = result[k];
                        result[k] = result[k + 1];
                        result[k + 1] = temp;
                    }
                }
            }

            for (int k = 0; k < result.Length; k++)
                {
                        Console.WriteLine((result[k]) );
                    if ((result.Length) % 2 == 0)
                    {
                     mid1 = (result.Length / 2) - 1;
                     mid2 = result.Length / 2;
                    median = Convert.ToDouble(result[mid1] + result[mid2]) / 2.0;
                    }
                    else
                    {
                        mid2 = (result.Length) / 2;
                        median = result[mid2];
                    }
                }
                return median;


            }
       
    }
}
