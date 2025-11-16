namespace Container_With_Most_Water
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = [1, 8, 6, 2, 5, 4, 8, 3, 7];
            int max=0;

            Program program = new Program();

            program.MaxArea(array);

        }
        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int maxArea = 0;

            while (left < right)
            {
                int width = right - left;
                int h = Math.Min(height[left], height[right]);
                int area = width * h;

                if (area > maxArea)
                    maxArea = area;

                // Move the pointer with smaller height
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return maxArea;
        }
    }
}
