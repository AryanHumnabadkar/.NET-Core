namespace NullableTypes
{
    internal class Program
    {
        static void Main()
        {
            int? x;
            x = 10;
            x = null;

            int y;
            if (x != null)
                y = (int)x;
            else
                y = 0;
            
            if (x.HasValue)
                y = x.Value;
            else
                y = 0;
            
            y = x.GetValueOrDefault();
            y = x.GetValueOrDefault(5);

            y = x ?? 0; //null coalescing operator

            Console.WriteLine(y);
        }

        static void Main(string[] args)
        {
            string s;
            //nullable reference type
            //string? s;  //use this to disable the null reference warning
            s = Console.ReadLine();
        }
    }
}
