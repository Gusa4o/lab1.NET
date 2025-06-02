using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science.Common
{
    public class Student : User
    {
        public string FavoriteGenre { get; set; }

        public Student(string name, int age, string favoritegenre)
            : base(name, age)
        {
            FavoriteGenre = favoritegenre;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Улюблений жанр: {FavoriteGenre}");
        }
    }
}