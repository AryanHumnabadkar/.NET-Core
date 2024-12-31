using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;

namespace DatabaseCode
{
    class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Connect();

            //InsertRecord();

            //Employee empObj = new Employee() { EmpNo = 113, Name = "Nikhil", Basic = 90000, DeptNo = 10 };
            //InsertUsingObj(empObj);

            //DeleteRecord(113);

            //Employee empObj = new Employee() { EmpNo = 113, Name = "Nikhil", Basic = 90000, DeptNo = 10 };
            //InsertUsingObjParameters(empObj);

            //DeleteRecord(113);

            //UpdateRecord(113, "Mukesh", 27, 20);

            //Employee empObj = new Employee() { EmpNo = 113, Name = "Nikhil", Basic = 90000, DeptNo = 10 };
            //InsertUsingStoredProcedure(empObj);

            //DeleteRecord(113);

            //ExecuteUsingScaler(111);

            //SelectUsingDataReader();

            //MultipleQueryUsingDataReader();

            //List<Employee> Employees = GetAllEmployees();
            //foreach (Employee emp in Employees)
            //{
            //    Console.WriteLine($"EmpNo : {emp.EmpNo}, Name : {emp.Name}, Basic : {emp.Basic} , DeptNo : {emp.DeptNo}");
            //}

            //Employee emp = GetSingleEmployee(103);
            //Console.WriteLine($"EmpNo : {emp.EmpNo}, Name : {emp.Name}, Basic : {emp.Basic} , DeptNo : {emp.DeptNo}");


        }
        static void Connect()
        {
            SqlConnection conn = new SqlConnection();
            //Data Source=(localdb)\ProjectModels;Initial Catalog=IACSDDec24;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";

            try
            {
                conn.Open();
                Console.WriteLine("Connection Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure" + ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
        static void InsertRecord()
        {
            SqlConnection conn = new SqlConnection();
            //Data Source=(localdb)\ProjectModels;Initial Catalog=IACSDDec24;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";

            try
            {
                conn.Open();
                Console.WriteLine("Connection Success");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Employees values (112,'Prathmesh',210000, 30)";
                cmd.ExecuteNonQuery();
                Console.WriteLine("Query Executed Succefully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure" + ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
        static void InsertUsingObjQueryConcat(Employee empObj)
        {
            SqlConnection conn = new SqlConnection();
            //Data Source=(localdb)\ProjectModels;Initial Catalog=IACSDDec24;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";

            try
            {
                conn.Open();
                Console.WriteLine("Connection Success");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"insert into Employees values ({empObj.EmpNo},'{empObj.Name}',{empObj.Basic},{empObj.DeptNo})";
                cmd.ExecuteNonQuery();
                Console.WriteLine("Query Executed Succefully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure" + ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
        /*
         * Problem With above Approch : ( Query String Concatenation )
         * 1. How to add Special Charachters in data ( eg. Name = D'Souza )
         * 2. SQL Injection Attack
         * 
         * Hense Never use Query String Concatenation
        */
        static void InsertUsingObjParameters(Employee empObj)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";

            try
            {
                conn.Open();
                Console.WriteLine("Connection Success");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Employees values (@EmpNo,@Name,@Basic,@DeptNo)";

                cmd.Parameters.AddWithValue("@EmpNo",empObj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", empObj.Name);
                cmd.Parameters.AddWithValue("@Basic", empObj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", empObj.DeptNo);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Query Executed Succefully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure" + ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
        static void InsertUsingStoredProcedure(Employee empObj)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";

            try
            {
                conn.Open();
                Console.WriteLine("Connection Success");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertEmployee";

                cmd.Parameters.AddWithValue("@EmpNo", empObj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", empObj.Name);
                cmd.Parameters.AddWithValue("@Basic", empObj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", empObj.DeptNo);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Query Executed Succefully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Query Execution Failed" + ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
        static void DeleteRecord(int EmpNo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";

            try
            {
                conn.Open();
                Console.WriteLine("Connection Success");
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Employees where EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                int rowaffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Record Deleted Successfully, {rowaffected} Affected");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure" + ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
        static void UpdateRecord(int EmpNo, string Name, decimal Basic, int DeptNo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";

            try
            {
                conn.Open();
                Console.WriteLine("Connection Success");
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Employees " +
                                    "set " +
                                    "Name = @Name, " +
                                    "Basic = @Basic, " +
                                    "DeptNo = @DeptNo  " +
                                    "where EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Basic", Basic);
                cmd.Parameters.AddWithValue("@DeptNo", DeptNo);

                int rowaffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Record Updated Successfully, {rowaffected} Affected");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure " + ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
        static void ExecuteUsingScaler(int EmpNo)//Selecting Single Value : First Column of First Row of Result Set. ( Else are ignored )
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";

            try
            {
                conn.Open();
                Console.WriteLine("Connection Success");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select name from Employees where EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                object name = cmd.ExecuteScalar();

                if ( name  == null)
                {
                    Console.WriteLine("Employee Not Found");
                }
                else
                {
                    Console.WriteLine($"Name of Employee with Emp No {EmpNo} is {name}");

                    Console.WriteLine("Query using Scaler Executed Succefully ");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure " + ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
        static void SelectUsingDataReader() //Selecting Multiple Values
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";

            try
            {
                conn.Open();
                Console.WriteLine("Connection Success");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine(reader[1]);//Index of Reader represents Column Number in Table.
                    //Console.WriteLine(reader["EmpNo"]);//Can Access using Name Also.
                    Console.WriteLine($"{reader[0]} => {reader[1]}");
                }
                reader.Close();
                Console.WriteLine("Query Executed Succefully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure " + ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
        static void MultipleQueryUsingDataReader()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";
            Console.WriteLine("Connection Successfull");
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees;select * from Departments";
                

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmpNo"]} => {reader["Name"]} => {reader["DeptNo"]}");
                }

                Console.WriteLine("------ First Query Executed Succefully ------");

                reader.NextResult();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["DeptNo"]} => {reader["DeptName"]}");
                }
                Console.WriteLine("------ Second Query Executed Succefully ------");
                reader.Close();
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Query Failure "+ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";
            Console.WriteLine("Connection Successfull");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee emp = new Employee() //Object Intialisers
                    {
                        Basic = (decimal)reader["Basic"],

                        EmpNo = reader.GetInt32("EmpNo"),
                        DeptNo = reader.GetInt32("DeptNo"),
                        Name = reader.GetString("Name")
                    };
                    employees.Add(emp);
                }
                reader.Close();
                Console.WriteLine("---List Genrated Succefully---");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Query Failure "+ ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");

            }

            return employees;

        }
        static Employee GetSingleEmployee(int EmpNo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";
            Console.WriteLine("Connection Successfull");
            Employee? emp = null ;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from employees where EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    emp = new Employee()
                    {
                        Basic = reader.GetDecimal("Basic"),
                        DeptNo = reader.GetInt32("DeptNo"),
                        Name = reader.GetString("Name"),
                        EmpNo = EmpNo
                    };
                    
                }
                else
                {
                    throw new Exception("Employee Not Found !!! Inavlid EmpNo.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Query Failure" + ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }

            return emp;
        }
    }
}
