using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRegistrySQL.Models
{
    class ServiceRecordModel
    {
        public int? RepairId { get; set; }
        public int ComputerId { get; set; }
        public DateTime DateRepair { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public ServiceRecordModel(int? repairId, int computerId, DateTime dateRepair, decimal price, string description)
        {
            RepairId = repairId;
            ComputerId = computerId;
            DateRepair = dateRepair;
            Price = price;
            Description = description;
        }

        public void Print()
        {
            Console.WriteLine($"ID сервисного обслуживания: {RepairId}");
            Console.WriteLine($"ID компьтера: {ComputerId}");
            Console.WriteLine($"Дата обслуживания: {DateRepair}");
            Console.WriteLine($"Стоимость: {Price}");
            Console.WriteLine($"Описание: {Description}");
        }
    }
}
