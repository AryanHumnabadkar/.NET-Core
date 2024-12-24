namespace Day3ClassWork
{
    internal class JaggedArrayDemo
    {
        static void Main(string[] args)
        {
            //  Center => Batch => Students => marks
            int CenterNum, BatchNum, StudentNum, marks;

            
            Console.WriteLine("Enter Total Number of Centers :");
            CenterNum = Convert.ToInt32(Console.ReadLine());
            int[][][] CenterArray = new int[CenterNum][][];
            for (int CenterIndex = 0; CenterIndex < CenterNum; CenterIndex++)
            {
                Console.WriteLine("Enter Number of Batches in " + (CenterIndex + 1) + " Center :");
                BatchNum = Convert.ToInt32(Console.ReadLine());
                CenterArray[CenterIndex] = new int[BatchNum][];
                for (int BatchIndex = 0; BatchIndex < BatchNum; BatchIndex++)
                {
                    Console.WriteLine("Enter Number of Students in " + (CenterIndex + 1)+" Center's " + (BatchIndex + 1 )+ " Batch");
                    StudentNum = Convert.ToInt32(Console.ReadLine());
                    CenterArray [CenterIndex][BatchIndex]= new int[StudentNum];
                    for(int StudentIndex = 0; StudentIndex < StudentNum; StudentIndex++)
                    {
                        Console.WriteLine("Enter Marks Of " +( CenterIndex +1 )+ " Center's " + (BatchIndex + 1) + " batche's " + (StudentIndex + 1 )+ " student :");
                        marks = Convert.ToInt32(Console.ReadLine());
                        CenterArray[CenterIndex][BatchIndex][StudentIndex] = marks;
                        
                    }
                    Console.WriteLine("---Marks Added for "+(BatchIndex + 1)+" Batch's Students !!!---");
                }
                Console.WriteLine("---Marks Added for " + (CenterIndex + 1 )+ " Center's Students !!!---");
            }
        }
    }
}
