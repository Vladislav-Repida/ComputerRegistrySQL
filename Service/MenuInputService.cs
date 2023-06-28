using ComputerRegistrySQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRegistrySQL.Service
{
    
    class MenuInputService
    {
        private ComputerRegistrySQLConnection connection;


        /// <summary>
        /// Ввод даты
        /// </summary>
        /// <param name="isCircular"></param>
        /// <returns></returns>
        DateTime InputDate(bool isCircular)
        {
            DateTime temp;
            do
            {
                string dateString = Console.ReadLine();
                if (DateTime.TryParse(dateString, out temp))
                {
                    return temp;
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Дата не валидна.");
                    if (isCircular)
                    {
                        Console.WriteLine("Попробуйте снова:");
                    }
                }
            } while (isCircular);

            return DateTime.Now;
        }

        /// <summary>
        ///   Ввод сотрудника
        /// </summary>
        /// <param name="empoyeeId"></param>
        /// <returns></returns>
        EmployeeModel InputEmployee(int? empoyeeId = null)
        {
            Console.WriteLine("Введите информацию о сотруднике:");
            Console.Write("ФИО сотрудника: ");
            string FullName = Console.ReadLine();
            Console.Write("Введите дату рождения сотрудника: ");
            DateTime dateTime = InputDate(true);

            return new EmployeeModel(empoyeeId, FullName, dateTime);
        }

        ComputerModel InputComputer(int? computerId = null)
        {

            int empoyeeId, ram;
            string cpu, gpu;

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите информацию о компьютере:");
                    Console.Write("ID сотрудника к которому привязан компьютер: ");
                    empoyeeId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Процессор: ");
                    cpu = Console.ReadLine();
                    Console.Write("Видеокарта: ");
                    gpu = Console.ReadLine();
                    Console.Write("Количество ОЗУ: ");
                    ram = Convert.ToInt32(Console.ReadLine());

                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Не валидные данные попробуйте сного");
                }
            }

            return new ComputerModel(computerId, empoyeeId, cpu, gpu, ram);
        }

        ServiceRecordModel InputServiceRecord(int? repairId = null)
        {
            int computerId;
            DateTime dateRepair;
            double price;
            string description;

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите информацию по сервисному ремонту");
                    Console.Write("Введите ID компьютера: ");
                    computerId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите дату починки: ");
                    dateRepair = InputDate(true);
                    Console.Write("Введите стоимость: ");
                    price = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите описание: ");
                    description = Console.ReadLine();

                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Не валидные данные попробуйте сного");
                }
            }

            return new ServiceRecordModel(repairId, computerId, dateRepair, price, description);
        }

        void PrintMenu()
        {
            Console.WriteLine("Введите номер команды:");
            Console.WriteLine("1) Добавить сотрудника");
            Console.WriteLine("2) Добавить компьютер");
            Console.WriteLine("3) Добавить запись о сервисном ремонте");
        }

        bool InputHandlerFromMenu(out bool exit)
        {
            exit = false;
            try
            {
                int menuItemIndex = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                switch (menuItemIndex)
                {
                    case 1:
                        connection.AddEmployee(InputEmployee());
                        return true;
                    case 2:
                        connection.AddComputer(InputComputer());
                        return true;
                    case 3:
                        connection.AddServiceRecord(InputServiceRecord());
                        return true;
                    default:
                        exit = true;
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        void EndWork()
        {
            Console.Clear();
            Console.WriteLine("Программа завершила работу...");
        }

        void InitMenu()
        {
            while (true)
            {
                Console.Clear();
                PrintMenu();
                InputHandlerFromMenu(out bool isExit);
                if (isExit)
                {
                    EndWork();
                    break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        public MenuInputService()
        {
            connection = new ComputerRegistrySQLConnection(@"Server=localhost;Database=ComputersRegistry;Trusted_Connection=True");
            InitMenu();
        }
    }
}
