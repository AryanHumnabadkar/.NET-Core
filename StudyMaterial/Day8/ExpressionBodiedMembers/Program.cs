namespace ExpressionBodiedMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Class1
    {
        //Methods
        public void Display() => Console.WriteLine("Display called");
        public int Add(int a, int b) => a + b;

        //property
        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        //read only property
        private string prop1;
        public string Prop1 => prop1;

        //constructor
        //only single statement is allowed
        //- so ideal for constructor with one parameter
        public Class1(string Name) => this.Name = Name;

    }
}