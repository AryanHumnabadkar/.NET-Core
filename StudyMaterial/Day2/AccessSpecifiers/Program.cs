namespace AccessSpecifiers
{
    //default access specifier is internal for members of a namespace
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass o = new BaseClass();
            //o.

            TestAccessSpecifiers.BaseClass o2 = new TestAccessSpecifiers.BaseClass();
            //o2.
        }
    }
    public class BaseClass
    {
        int a;  //default access specifier is private for members of a class
        //public - available everywhere
        //private - same class
        //protected - same class,  derived class
        //internal - same class, same assembly(same project)
        //protected internal - same class,  derived class, same assembly(same project)
        //private protected - same class,  derived class that is in the same assembly
        public int PUBLIC;
        private int PRIVATE;
        protected int PROTECTED;
        internal int INTERNAL;
        protected internal int PROTECTED_INTERNAL;
        private protected int PRIVATE_PROTECTED;
    }
    public class DerivedClass : TestAccessSpecifiers.BaseClass  //:  BaseClass 
    {
        void DoSomething()
        {
            //this.
        }
    }
}
