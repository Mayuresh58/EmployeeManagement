using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class EmployeeDAL
{
    private string connectionString = "Data Source=DESKTOP-KNL5H8M\\SQLEXPRESS01;Initial Catalog = EmployeeDB; Integrated Security = True; TrustServerCertificate=True";


    public List<Employee> GetAllEmployees()
    {
        List<Employee> employees = new List<Employee>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee emp = new Employee
                {
                    EmployeeID = (int)reader["EmployeeID"],
                    Name = reader["Name"].ToString(),
                    Department = reader["Department"].ToString(),
                    Salary = (decimal)reader["Salary"]
                };
                employees.Add(emp);
            }
        }
        return employees;
    }


    public void AddEmployee(Employee emp)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Employees (Name, Department, Salary) VALUES (@Name, @Department, @Salary)", conn);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }


    public void UpdateEmployee(Employee emp)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE Employees SET Name=@Name, Department=@Department, Salary=@Salary WHERE EmployeeID=@EmployeeID", conn);
            cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }


    public void DeleteEmployee(int employeeID)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmployeeID=@EmployeeID", conn);
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
