namespace Day5Classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DerivedClass obj = new DerivedClass(10);
            //Console.WriteLine(obj.);
        }
    }
    class BaseClass
    {
        int a;
        //public int A
        //{
        //    get
        //    {
        //        return a;
        //    }
        //    set
        //    {
        //        a = value;
        //    }
        //}
        public BaseClass(int abc)
        { this.a = a; }
    }
    class DerivedClass : BaseClass
    {
        int b;
        public DerivedClass(int b) : base(20)
        { this.b = b; }
    }
}
