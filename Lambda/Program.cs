using System;
using System.Collections.Generic;

namespace Lambda
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Func<string, int> returnLength;

            //returnLength = delegate (string text) { return text.Length; };

            //returnLength = (string text) => { return text.Length; };

            //returnLength = text => text.Length;

            Action<Film> print =
                film => Console.WriteLine("Name: {0}, Year: {1}", film.Name, film.Year);

            var films = GetFilms();

            films.ForEach(print);

            films.FindAll(film => film.Year > 1980).ForEach(print);

            films.Sort((f1, f2) => f1.Year.CompareTo(f2.Year));

            films.ForEach(print);

           // Console.WriteLine(returnLength("Hello"));
        }

        public static List<Film> GetFilms()
        {
            var films = new List<Film>
            {
                new Film("Jaws", 1981),
                new Film("Superman", 1977),
                new Film("Matrix", 1999),
                new Film("Back to the future", 1985)
            };

            return films;
        }
    }
}
