using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadOfEmp_PayRoll
{
    public class EmployeePayRoll
    {
        public static string dbpath = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employ_PayRoll;Integrated Security=True";
        public List<EmployeeModalClass> employeeList = new List<EmployeeModalClass>();
        public void CreateNewContact(EmployeeModalClass model)
        {
            SqlConnection connect = new SqlConnection(dbpath);
            using (connect)
            {
                connect.Open();
                SqlCommand sql = new SqlCommand("SP_EmployeeDetails", connect);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@NAME", model.NAME);
                sql.Parameters.AddWithValue("@SALARY", model.SALARY);
                sql.Parameters.AddWithValue("@START", model.START);
                sql.Parameters.AddWithValue("@GENDER", model.gender);
                sql.Parameters.AddWithValue("@PHONENO", model.PHONENO);
                sql.Parameters.AddWithValue("@ADDRESS", model.ADDRESS);
                sql.Parameters.AddWithValue("@DEPARTMENT", model.DEPARTMENT);
                sql.Parameters.AddWithValue("@BASIC_PAY", model.BASIC_PAY);
                sql.ExecuteNonQuery();
                Console.WriteLine("Record created successfully.");
                connect.Close();
            }
        }
        public void AddNewEmployeeToPayRoll(List<EmployeeModalClass> employeeList)
        {
            foreach (EmployeeModalClass modal in employeeList)
            {
                this.CreateNewContact(modal);
                Console.WriteLine("Employee Added: " + modal.NAME);
            }
        }
        public void AddNewEmployeeUsingMultiThread(List<EmployeeModalClass> employeeList)
        {
            foreach (EmployeeModalClass modal in employeeList)
            {
                Task Thread = new Task(() =>
                {
                    this.CreateNewContact(modal);
                    Console.WriteLine("Employee Added: " + modal.NAME);
                });
                Thread.Start();
            }
            Console.WriteLine(this.employeeList.Count);
        }
        public void addEmployeePayRoll(EmployeeModalClass emp)
        {
            employeeList.Add(emp);

        }
        public int EmployeeCount()
        {
            return this.employeeList.Count;
        }
    }
}
