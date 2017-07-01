using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularTrack
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isCorrectInput = false;

            while (!isCorrectInput)
            {
                Console.WriteLine("Please enter the amount of train cars or 'q' to quit:");

                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (input.ToLower() != "q")
                    {
                        int amount = 0;

                        if (Int32.TryParse(input, out amount))
                        {
                            if (amount > 1)
                            {
                                isCorrectInput = true;

                                var trainCarCalculator = new TrainCarCalculator();

                                Console.WriteLine("The amount of cars is:" + trainCarCalculator.Calculate(amount));
                                Console.WriteLine("Press any key to quit");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("The number of cars must be at least 2.");
                            }
                        }
                    }
                    else
                    {
                        isCorrectInput = true;
                        Console.WriteLine("Bye, thanks");
                    }
                }
            }
        }
    }

    public class TrainCar
    {
        public TrainCar Next { get; set; }

        public TrainCar Previous { get; set; }

        public bool IsLightOn { get; set; }

        public int Number { get; set; }

        public TrainCar()
        {
            IsLightOn = true;
        }

        public TrainCar(int number)
        {
            Number = number;
            IsLightOn = true;
        }
    }


    class TrainCarCalculator
    {
        public int Calculate(int amount)
        {
            var head = new TrainCar(1);

            var tail = new TrainCar(amount);

            head.Previous = tail;

            tail.Next = head;

            if (amount > 2)
            {
                var current = head;

                for (int index = 1; index < amount - 1; index++)
                {
                    var nextTrainCar = new TrainCar(index + 1);

                    nextTrainCar.Previous = current;

                    current.Next = nextTrainCar;

                    current = current.Next;
                }

                current.Next = tail;

                tail.Previous = current;
            }
            else
            {
                head.Next = tail;

                tail.Previous = head;
            }

            return -1;
        }
    }
}
