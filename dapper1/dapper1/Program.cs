using Dapper;
using dapper1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dapper1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create connection string
            string connectionString = "Server=ryz\\SQLEXPRESS_SS; Initial Catalog=test1; TrustServerCertificate=True; user id=admin;password=passw0rd";

            // Create connection as SqlConnection object
            SqlConnection connection = new SqlConnection(connectionString);



            // INSERT <=========================
            // open connection
            connection.Open();

            // Create object here
            Employee e1 = new Employee
            {
                employeeName = "Obama",
                employeeCar = "Cadilac",
                employeeNumber = 147
            };
            
            string insertQuery = "INSERT INTO Employee (employeeName,employeeCar,employeeNumber) VALUES (@employeeName, @employeeCar, @employeeNumber);";

            // query worked fine
            //connection.Query(insertQuery, e1);

            // query worked fine
            int recordsAffected = connection.Execute(insertQuery, e1);
            Console.WriteLine("recordsAffected: " + recordsAffected);

            connection.Close();

            // SELECT <=========================
            connection.Open();
            string selectQuery = "SELECT * FROM Employee";
            List<Employee> employees = connection.Query<Employee>(selectQuery).ToList();
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.employeeName} - {employee.employeeNumber}");
            }
            connection.Close();

            // UPDATE <=========================
            string updateQuery = "UPDATE Employee SET employeeName = @employeeName WHERE employeeNumber = @employeeNumber";
            Employee employeeUpdate = new Employee
            {
                employeeNumber = 42,
                employeeName = "MarranaUpdated1",
            };
            connection.Execute(updateQuery, employeeUpdate);
            connection.Close();

            // DELETE <=========================
            string deleteQuery = "DELETE FROM Employee WHERE employeeNumber = @employeeNumber";
            recordsAffected = connection.Execute(deleteQuery, new { employeeNumber = 84 });
            Console.WriteLine($"recordsAffected: {recordsAffected}");

        }
    }
}
