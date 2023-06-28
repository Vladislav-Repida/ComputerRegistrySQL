using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRegistrySQL.Models
{
    class EmployeeModel
    {
        public int? EmployeeId { get; set; }
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }

        public EmployeeModel(int? employeeId, string fullName, DateTime dateBirth)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            DateBirth = dateBirth;
        }
    }
}
