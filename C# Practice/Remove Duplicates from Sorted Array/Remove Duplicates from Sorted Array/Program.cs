namespace Remove_Duplicates_from_Sorted_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Program p= new Program();
            //p.RemoveDuplicates([1, 1, 2]);
            p.RemoveDuplicates([0, 0, 1, 1, 1, 2, 2, 3, 3, 4]);


        }

       
      public void RemoveDuplicates(int[] nums)
        {

            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                    Console.WriteLine(nums[i]);
                }
                
            }
            
            //return i + 1;


        }
    }
}
