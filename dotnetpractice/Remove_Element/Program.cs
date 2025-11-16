namespace Remove_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = [3, 2, 2, 3];
            int K;
            Console.WriteLine("Enter the no wich you want to remove");
            K = Convert.ToInt32(Console.ReadLine());
            
            // Bothe logic are correct
            //var result = from i in nums where i != K select i;

            //foreach (int i in result)
            //{
            //    Console.WriteLine(i);


            //}
           int result = RemoveElement(nums, K);

            Console.WriteLine($"{result}");
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int k=0;
            for(int i = 0; i < nums.Length;i++)
            {
                if (nums[i] != nums[val])
                {
                    k++;
                }
            }
            return k;
        }
    }
}
