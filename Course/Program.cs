﻿using System;
using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;

namespace Course {
    class Program {
        static void Main(string[] args) {
            Console.Write("Enter department's name: ");
            Department dept = new Department(Console.ReadLine());

            Console.WriteLine("Enter work data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("How many contracts to this worker? ");
            int numContracts = int.Parse(Console.ReadLine());

            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine();

            for (int i = 1; i <= numContracts; i++) {
                Console.WriteLine($"Enter #{i} contract data:");

                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration: ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);

                worker.AddContract(contract);

                Console.WriteLine();
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY):  ");
            string monthAndYear = Console.ReadLine();

            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            
            Console.WriteLine("Name: " + worker.Name);

            Console.WriteLine("Department: " + worker.Department.Name);

            Console.WriteLine("Income for 08/2018: " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
