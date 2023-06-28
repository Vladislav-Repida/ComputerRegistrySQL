using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRegistrySQL.Models
{
    class ComputerModel
    {
        public int? ComputerId { get; set; }
        public int EmployeeId { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public int Ram { get; set; }

        public ComputerModel(int? computerId, int employeeId, string cpu, string gpu, int ram)
        {
            ComputerId = computerId;
            EmployeeId = employeeId;
            Cpu = cpu;
            Gpu = gpu;
            Ram = ram;
        }

        public void Print()
        {
            Console.WriteLine($"ID компьютера: {ComputerId}");
            Console.WriteLine($"ID сотрудника: {EmployeeId}");
            Console.WriteLine($"CPU: {Cpu}");
            Console.WriteLine($"GPU: {Gpu}");
            Console.WriteLine($"RAM: {Ram}");
        }
    }
}
