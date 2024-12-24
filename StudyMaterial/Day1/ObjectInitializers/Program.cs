namespace ObjectInitializers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 o1 = new Class1();
            o1.P1 = 1;
            o1.P2 = 2;
            o1.P3 = 3;

            Class1 o2 = new Class1() { P1 = 4, P2 = 5, P3 = 6 };
            Class1 o3 = new Class1 { P1 = 1, P2 = 2, P3 = 3 };


            Class2 o4 = new Class2() { P1 = 1, P2 = 2, P3 = 3 };
            Class2 o5 = new Class2(1,2,3);


        }
    }
    public class Class1
    {
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }

    }

    public class Class2
    {
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public Class2(int P1 = 8, int P2 = 9, int P3 = 10)
        {
            this.P1 = P1;
            this.P2 = P2;
            this.P3 = P3;
        }

    }
}
