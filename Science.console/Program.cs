using Science.Common;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Science.Common
{
    internal class Program
    {
        public delegate void TicketAddedHandler(Enrollment enrollment);
        public static event TicketAddedHandler? OnEnrollmentAdded;
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            var courseService = new CrudService<Course>();

            courseService.Create(new Course("Основи програмування", "Інформатика", 2023, 8.6));
            courseService.Create(new Course("Історія ХХ століття", "Історія", 2022, 7.8));
            courseService.Create(new Course("Критичне мислення", "Філософія", 2019, 8.2));
            courseService.Create(new Course("Основи журналістики", "Журналістика", 2018, 8.2));
            courseService.Create(new Course("Сучасна література", "Література", 2019, 7.9));
            courseService.Create(new Course("Безпека онлайн", "Кібербезпека", 2017, 5.3));

            string filePath = "courses.json";

            courseService.Save(filePath);
            System.Console.WriteLine($"\nДані збережено у файл: {filePath}");

            System.Console.WriteLine("\nПісля очищення:");
            var emptyService = new CrudService<Course>();
            foreach (var m in emptyService.ReadAll())
            {
                System.Console.WriteLine(m);
            }

            emptyService.Load(filePath);
            System.Console.WriteLine("\nПісля завантаження з файлу:");
            foreach (var m in emptyService.ReadAll())
            {
                System.Console.WriteLine(m);
            }


            System.Console.WriteLine("Список курсів\n");

            foreach (var course in courseService.ReadAll())
            {
                System.Console.WriteLine(course);
            }

            List<Enrollment> enrollment = new List<Enrollment>();

            OnEnrollmentAdded += enrollment =>
            {
                System.Console.WriteLine($"\nДодано новий курс: {enrollment}");
            };

            AddEnrollment(enrollment, new Enrollment("Основи програмування", DateTime.Now.AddHours(2), 100));
            AddEnrollment(enrollment, new Enrollment("Історія ХХ століття", DateTime.Now.AddHours(3), 200));
            AddEnrollment(enrollment, new Enrollment("Критичне мислення", DateTime.Now.AddHours(4), 150));
            AddEnrollment(enrollment, new Enrollment("Основи журналістики", DateTime.Now.AddHours(4), 110));
            AddEnrollment(enrollment, new Enrollment("Сучасна література", DateTime.Now.AddHours(4), 120));
            AddEnrollment(enrollment, new Enrollment("Безпека онлайн", DateTime.Now.AddHours(4), 90));

            System.Console.WriteLine("\nСписок записів:\n");
            foreach (var ticket in enrollment)
            {
                System.Console.WriteLine(ticket);
            }

            System.Console.WriteLine($"\nЗагальна сума продажів: {enrollment.CalculateTotalPrice()} $");

            System.Console.ReadLine();
        }
        public static void AddEnrollment(List<Enrollment> enrollment, Enrollment newEnrollment)
        {
            enrollment.Add(newEnrollment);
            OnEnrollmentAdded?.Invoke(newEnrollment);
        }
    }

}