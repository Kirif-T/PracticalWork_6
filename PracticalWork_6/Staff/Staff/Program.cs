using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Staff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Вывести данные на экран");
            Console.WriteLine("2 - Добавить нового сотрудника");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ReadEmployees();
                    break;
                case "2":
                    AddEmployee();
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                    break;
            }
        }

        // Метод для чтения данных из файла
        static void ReadEmployees()
        {
            const string filePath = "Сотрудники.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('#');
                    Console.WriteLine($"ID: {parts[0]}, Дата записи: {parts[1]}, ФИО: {parts[2]}, Возраст: {parts[3]}, Рост: {parts[4]}, Дата рождения: {parts[5]}, Место рождения: {parts[6]}");
                }
            }
            else
            {
                Console.WriteLine("Файл сотрудников не найден.");
            }
        }

        // Метод для добавления нового сотрудника
        static void AddEmployee()
        {
            const string filePath = "Сотрудники.txt";

            // Получаем ID на основе количества строк в файле
            int id = File.Exists(filePath) ? File.ReadAllLines(filePath).Length + 1 : 1;
            string recordDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();

            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Введите рост: ");
            int height = int.Parse(Console.ReadLine());

            Console.Write("Введите дату рождения (дд.мм.гггг): ");
            string birthDate = Console.ReadLine();

            Console.Write("Введите место рождения: ");
            string birthPlace = Console.ReadLine();

            string newEmployee = $"{id}#{recordDate}#{name}#{age}#{height}#{birthDate}#{birthPlace}";

            // Добавляем запись в конец файла
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(newEmployee);
            }

            Console.WriteLine("Новая запись успешно добавлена.");
        }
    }
}
