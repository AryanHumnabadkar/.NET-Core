namespace ParamsExample
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine(Add(1, 2, 3));
            Console.WriteLine(Add(1, 2, 3, 4, 5));
            Console.WriteLine(Add(1, 2, 3, 4, 5, 6, 7,8,9));

        }
        //       static int Add(params int[] arr)
       //        static int Add(params int[] arr, int a) //error - params needs to be last

        //static int Add(int a, params int[] arr) //-- okay
        static int Add(params int[] arr)
        {
            int sum = 0;
            foreach (int item in arr)
            {
                sum += item;
            }
            return sum;
        }
    }
}
