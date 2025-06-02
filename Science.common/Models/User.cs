using System;

namespace Science.Common
{
    public abstract class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public static int TotalPeople = 0;

        static User()
        {
            Console.WriteLine("Створено клас User");
        }

        public User(string name, int age)
        {
            ID = Guid.NewGuid();
            Name = name;
            Age = age;
            TotalPeople++;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Ім'я: {Name}, Вік: {Age}");
        }
    }
}