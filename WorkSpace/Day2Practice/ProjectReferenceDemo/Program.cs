namespace ProjectReferenceDemo
{
    public class PClass
    {
        public int P1 { get; set; }
        public int P2 { get; set; }

        //public PClass()
        //{
        //    P1 = 8;
        //    P2 = 10;
        //}

        public PClass(int P1 = 8, int P2 = 10)
        {
            this.P1 = P1;
            this.P2 = P2;
        }

        public static void Main(string[] args)
        {

        }
    }
}
