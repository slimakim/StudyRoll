using System;
using StudyRoll.Structs;



namespace StudyRoll
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Coordinate c1 = new Coordinate(10.9, 156.1);
            Coordinate c2 = new Coordinate()
            {
                Latitude = 14.3,
                Longitude = 11.2
            };
            Coordinate c3 = new Coordinate();


            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(c3);

        }
    }
}
