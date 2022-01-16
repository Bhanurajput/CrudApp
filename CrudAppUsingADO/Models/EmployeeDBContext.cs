using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;



namespace CrudAppUsingADO.Models
{
    public class EmployeeDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Employee> GetEmployees()
        {
            List<Employee> EmployeeList = new  List<Employee>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Get_Employee_Detail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee Emp = new Employee();
                Emp.Id = Convert.ToInt32(dr.GetValue(0).ToString());
                Emp.Name =dr.GetValue(1).ToString();
                Emp.Gender =dr.GetValue(2).ToString();
                Emp.Age = Convert.ToInt32(dr.GetValue(3).ToString());
                Emp.salary = Convert.ToInt32(dr.GetValue(4).ToString());
                EmployeeList.Add(Emp);
            }

            con.Close();

            return EmployeeList;          
        }

        public bool AddEmployee(Employee Emp)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("CRUD", con);//AddEmployee
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Operation", "INSERT");
            cmd.Parameters.AddWithValue("@id",Emp.Id);
            cmd.Parameters.AddWithValue("@Name", Emp.Name);
            cmd.Parameters.AddWithValue("@Gender", Emp.Gender);
            cmd.Parameters.AddWithValue("@Age", Emp.Age);
            cmd.Parameters.AddWithValue("@Salary", Emp.salary);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();

            if (a > 0)
                return true;
            else
                return false;
        }

        public bool UpdateEmployee(Employee Emp)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("CRUD", con); //UpdateEmployee
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Operation", "UPDATE");
            cmd.Parameters.AddWithValue("@id", Emp.Id);
            cmd.Parameters.AddWithValue("@Name", Emp.Name);
            cmd.Parameters.AddWithValue("@Gender", Emp.Gender);
            cmd.Parameters.AddWithValue("@Age", Emp.Age);
            cmd.Parameters.AddWithValue("@Salary", Emp.salary);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();

            if (a > 0)
                return true;
            else
                return false;
        }

        public bool DeleteEmployee(int Id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("CRUD", con);//DeleteEmployee
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Operation", "DELETE");
            cmd.Parameters.AddWithValue("@id",Id);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();

            if (a > 0)
                return true;
            else
                return false;
        }


    }
}