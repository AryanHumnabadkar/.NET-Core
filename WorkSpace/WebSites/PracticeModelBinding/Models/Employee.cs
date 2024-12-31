using Microsoft.Data.SqlClient;
using System.Data;

namespace ModelBinding.Models
{

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public static Employee GetSingleEmployee(int EmpNo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\ProjectModels;Initial Catalog = IACSDDec24; Integrated Security = True;";
            //Console.WriteLine("Connection Successfull");
            Employee? emp = null;

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
                throw ex;
                //Console.WriteLine("Query Failure" + ex.Message);
            }
            finally
            {
                conn.Close();
                //Console.WriteLine("Connection Closed");
            }

            return emp;
        }
        public static List<Employee> GetAllEmployees()
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
            catch (Exception ex)
            {
                Console.WriteLine("Query Failure " + ex.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed");

            }

            return employees;

        }
        public static void InsertUsingStoredProcedure(Employee empObj)
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
        public static void UpdateRecord(int EmpNo, string Name, decimal Basic, int DeptNo)
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
        public static void DeleteRecord(int EmpNo)
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





    }

}
