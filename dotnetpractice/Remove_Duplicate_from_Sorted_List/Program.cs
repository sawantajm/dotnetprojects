namespace Remove_Duplicate_from_Sorted_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4];
            //int j = 0;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if(array[i] != array[j])
            //    {
            //        j++;
            //        array[j]=array[i];
            //        Console.WriteLine(j);
            //    }    
            //}
            RemoveDuplicates(array);

        }

        public static int RemoveDuplicates(int[] nums)
        {

            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                    Console.WriteLine(nums[i]);
                }
            }
            return i + 1;
        }
    }
}
