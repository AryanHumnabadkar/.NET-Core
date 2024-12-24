namespace Arrays
{
    internal class Program
    {
        static void Main1()
        {
            int[] arr= new int[5];
            //arr[0] .... arr[4]
            for (int i = 0; i < arr.Length; i++)
            {
                //Console.WriteLine("Enter value for arr[" + i + "]"); //concatenation
                //Console.WriteLine("Enter value for arr[{0}]", i);  //placeholder
                //Console.Write($"Enter value for arr[{i}] : ");  //interpolation
                //arr[i] = Convert.ToInt32(Console.ReadLine());
                //arr[i] = int.Parse(Console.ReadLine()!);
                arr[i] = int.Parse(Console.ReadLine());
            }
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    //Console.WriteLine("value for arr[{0}] is {1}", i, arr[i]);  //placeholder
            //    Console.WriteLine($"value for arr[{i}] is {arr[i]}");  //interpolation
            //}
            foreach(int item in arr)
            {
                //item = 10; //error - item is readonly
                Console.WriteLine(item);
            }
        }
        static void Main2()
        {
            //int[] arr = { 1, 2, 3, 4, 5, 6 };
            int[] arr = new int[5]{ 10, 20, 30, 40,50 };
            //int pos = Array.IndexOf(arr, 20);
            //int pos = Array.LastIndexOf(arr, 20);
            //if (pos == -1)
            //    Console.WriteLine("not found");
            int pos = Array.BinarySearch(arr, 20);
            Console.WriteLine(pos);
            //if (pos < 0)
            //    Console.WriteLine("not found");


            //Array.Clear(arr); //sets all elemets to def value
            //Array.Copy(arr,arr2,arr.Length);
            //Array.ConstrainedCopy(arr,0,arr2,0,arr.Length);
            //Array.Reverse(arr);
            //Array.Sort(arr);


        }
        static void Main3()
        {
            //3 students, 2 marks
            int[,] arr = new int[3, 2];
            //arr[0,0] arr[0,1]
            //arr[1,0] arr[1,1]
            //arr[2,0] arr[2,1]
            //Console.WriteLine(arr.Rank); //no of dimensions - 2
            //Console.WriteLine(arr.Length); //6
            //Console.WriteLine(arr.GetLength(0)); //3
            //Console.WriteLine(arr.GetLength(1)); //2
            //Console.WriteLine(arr.GetUpperBound(0)); //2
            //Console.WriteLine(arr.GetUpperBound(1)); //1
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"Enter value for arr[{i},{j}] : ");  //interpolation
                    arr[i, j] = int.Parse(Console.ReadLine());
                }

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine($"value for arr[{i},{j}] is {arr[i,j]}");  //interpolation
                }

        }
        static void Main()
        {
            //jagged
            int[][] arr = new int[4][];

            //for (int i = 0; i < arr.Length; i++)
            //arr[i] = new int[X]

            arr[0] = new int[3]; // arr[0][0] arr[0][1] arr[0][2]
            arr[1] = new int[4]; // arr[1][0] arr[1][1] arr[1][2] arr[1][3]
            arr[2] = new int[2];//  arr[2][0] - arr [2][1]
            arr[3] = new int[3];//  arr[3][0] arr[3][1] arr[3][2]

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("enter value for subscript [{0}][{1}] : ", i, j);
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
                Console.WriteLine();
            }


            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine("value for subscript {0},{1} is {2}  ", i, j, arr[i][j]);

                }
            }
            Console.ReadLine();
        }
        static void Main5()
        {
            Employee[] arr = new Employee[5];
            //arr[0] = new Employee();
            //arr[1] = new Employee();
            //arr[2] = new Employee();
            //arr[3] = new Employee();
            //arr[4] = new Employee();
            for (int i = 0;i < arr.Length;i++)
            {
                arr[i] = new Employee();
                arr[i].EmpNo = Convert.ToInt32(Console.ReadLine());
                arr[i].Name = Console.ReadLine();
            }
            foreach (Employee e in arr)
            {
                //e = new Employee();  //error - readonly
                //e.EmpNo = Convert.ToInt32(Console.ReadLine());
                //e.Name = Console.ReadLine();
                Console.WriteLine(e.EmpNo);
                Console.WriteLine(e.Name);
            }
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
    }
}
