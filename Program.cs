using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ComputerRegistrySQL.Models;
using ComputerRegistrySQL.Service;

namespace ComputerRegistrySQL
{
   class Program
    {
        static void Main()
        {
            var computerRegistryMenu = new MenuInputService();
        }
    }
}
