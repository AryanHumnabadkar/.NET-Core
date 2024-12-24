namespace AnonymousMethods
{
    internal class Program
    {
        static void Main()
        {
            int i = 100;
            Action o1 = delegate()
            {
                //can access local variables
                ++i;
                Console.WriteLine(i);
                Console.WriteLine("Display called");
            };
            o1();

            Func<int, int, int> o2 = delegate (int x, int y)
            {
                return x + y;
            };

            Console.WriteLine(o2(10,4));
        }
        static void Display()
        {
            Console.WriteLine("Display called");
        }
        //static int Add(int a, int b)
        //{
        //    return a + b;
        //}
    }
}
