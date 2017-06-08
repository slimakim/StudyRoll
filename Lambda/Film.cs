using System;
namespace Lambda
{
    public class Film
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public Film(string name, int year)
        {
            this.Name = name;
            this.Year = year;
        }
    }
}
