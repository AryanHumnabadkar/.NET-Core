using System.Reflection;
namespace ReflectionExample
{
    internal class Program
    {
        static void Main()
        {
            //D:\Trainings\YCPOct24\Day1\ClassBasics\bin\Debug\net8.0\ClassBasics.dll

            //Assembly asm = Assembly.GetExecutingAssembly(); //currently running assembly

            //Assembly asm = Assembly.GetCallingAssembly();
            //Assembly asm = Assembly.GetEntryAssembly();
            //Assembly asm = Assembly.GetAssembly(typeof(string));
            Assembly asm = Assembly.LoadFile("D:\\Trainings\\YCPOct24\\Day1\\ClassBasics\\bin\\Debug\\net8.0\\ClassBasics.dll");

            //Console.WriteLine(asm.FullName);
            Console.WriteLine(asm.GetName().Name);
            Type[] arrTypes = asm.GetTypes();
            foreach (Type t in arrTypes)
            {
                Console.WriteLine("    "+ t.Name);
                MethodInfo[] arrMethods = t.GetMethods();
                foreach (MethodInfo m in arrMethods)
                {
                    Console.WriteLine("        "+ m.Name);
                }
            }


        }
    }
}
//asm1 --> asm2 ---> asm3 ---> asm4