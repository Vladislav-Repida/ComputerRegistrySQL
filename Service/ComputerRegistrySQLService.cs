using ComputerRegistrySQL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRegistrySQL
{
    internal class ComputerRegistrySQLService
    {
        private string connectionSting;
        private SqlConnection connection;

        private void Connect()
        {
            connection = new SqlConnection(connectionSting);
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ExecuteNonQuery(string sqlString)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = sqlString;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private SqlDataReader ExecuteWithQuery(string sqlString)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = sqlString;
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public void AddEmployee(EmployeeModel employee)
        {
            var sqlString = $"INSERT INTO Employees (FullName, DateBirth) VALUES ('{employee.FullName}', '{employee.DateBirth}')";
            ExecuteNonQuery(sqlString);
        }

        public void AddComputer(ComputerModel computer)
        {
            var sqlString = $"INSERT INTO Computers (EmployeeId, CPU, GPU, RAM) VALUES ('{computer.EmployeeId}', '{computer.Cpu}', '{computer.Gpu}', '{computer.Ram}')";
            ExecuteNonQuery(sqlString);
        }
        public void AddServiceRecord(ServiceRecordModel serviceRecord)
        {
            var sqlString = $"INSERT INTO ServiceRepair (ComputerId, DateRepair, Price, Description) VALUES ('{serviceRecord.ComputerId}', '{serviceRecord.DateRepair}', '{serviceRecord.Price}', '{serviceRecord.Description}')";
            ExecuteNonQuery(sqlString);
        }

        public List<EmployeeModel> GetEmployees()
        {
            SqlDataReader reader = ExecuteWithQuery("SELECT * FROM Employees");
            List <EmployeeModel> employees = new List<EmployeeModel>();

            if(reader != null)
            {
                while (reader.Read()) 
                {
                    try
                    {
                        int empoyeeId = reader.GetInt32(0);
                        string fullname = reader.GetString(1);
                        DateTime dateBirth = reader.GetDateTime(2);

                        employees.Add(new EmployeeModel(empoyeeId, fullname, dateBirth));
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            reader.Close();
            return employees;
        }

        public List<ComputerModel> GetComputers()
        {
            SqlDataReader reader = ExecuteWithQuery("SELECT * FROM Computers");
            List<ComputerModel> computers = new List<ComputerModel>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    try
                    {
                        int computerId = reader.GetInt32(0);
                        int empoyeeId = reader.GetInt32(1);
                        string cpu = reader.GetString(2);
                        string gpu = reader.GetString(3);
                        int ram = reader.GetInt32(4);

                        computers.Add(new ComputerModel(empoyeeId, empoyeeId, cpu, gpu, ram));
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            reader.Close();
            return computers;
        }

        public List<ServiceRecordModel> GetServiceRecords()
        {
            SqlDataReader reader = ExecuteWithQuery("SELECT * FROM ServiceRepair");
            List<ServiceRecordModel> serviceRecords = new List<ServiceRecordModel>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    try
                    {
                        int repairId = reader.GetInt32(0);
                        int computerId = reader.GetInt32(1);
                        DateTime dateRepair = reader.GetDateTime(2);
                        decimal price = reader.GetDecimal(3);
                        string description = reader.GetString(4);

                        serviceRecords.Add(new ServiceRecordModel(repairId, computerId, dateRepair, price, description));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }
            reader.Close();
            return serviceRecords;
        }

        public ComputerRegistrySQLService(string connectionSting)
        {
            this.connectionSting = connectionSting;
            Connect();
        }
    }
}
