using ComputerRegistrySQL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRegistrySQL
{
    internal class ComputerRegistrySQLConnection
    {
        private string connectionSting;
        private EnumConnectionStatus connectStatus = EnumConnectionStatus.Disconnected;
        private SqlConnection connection;

        private void Connect()
        {
            connection = new SqlConnection(connectionSting);
            try
            {
                // Открываем подключение
                connection.Open();
                connectStatus = EnumConnectionStatus.Connected;
                Console.WriteLine("Подключение открыто");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Execute(string sqlString)
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

        public void AddEmployee(EmployeeModel employee)
        {
            var sqlString = $"INSERT INTO Employees (FullName, DateBirth) VALUES ('{employee.FullName}', '{employee.DateBirth}')";
            Execute(sqlString);
        }

        public void AddComputer(ComputerModel computer)
        {
            var sqlString = $"INSERT INTO Computers (EmployeeId, CPU, GPU, RAM) VALUES ('{computer.EmployeeId}', '{computer.Cpu}', '{computer.Gpu}', '{computer.Ram}')";
            Execute(sqlString);
        }
        public void AddServiceRecord(ServiceRecordModel serviceRecord)
        {
            var sqlString = $"INSERT INTO ServiceRepair (ComputerId, DateRepair, Price, Description) VALUES ('{serviceRecord.ComputerId}', '{serviceRecord.DateRepair}', '{serviceRecord.Price}', '{serviceRecord.Description}')";
            Execute(sqlString);
        }

        public ComputerRegistrySQLConnection(string connectionSting)
        {
            this.connectionSting = connectionSting;
            Connect();
        }
    }
}
