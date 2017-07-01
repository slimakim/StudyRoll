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
                                var trainCarCalculator = new TrainCarCalculator(amount);
                                Console.WriteLine("The amount of cars is:" + trainCarCalculator.CalculatedSize);
                                Console.WriteLine("Press any key to continue, or press 'q' to quit");
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
        private int _calculatedSize;

        public int CalculatedSize
        {
            get { return _calculatedSize; }
        }

        public TrainCarCalculator(int amount)
        {
            _calculatedSize = Calculate(ConstructTrain(amount));
        }

        public TrainCar ConstructTrain(int carAmount)
        {
            var head = new TrainCar(1);

            var tail = new TrainCar(carAmount);

            head.Previous = tail;

            tail.Next = head;

            if (carAmount > 2)
            {
                var current = head;

                for (int index = 1; index < carAmount - 1; index++)
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

            return head;
        }

        public int Calculate(TrainCar trainCar)
        {
            bool isLightBulbOn = true;

            int level = 1;

            int stepsTaken = 0;

            while (isLightBulbOn)
            {
                WalkLeft(trainCar.Next, level);

                WalkRight(trainCar.Previous, level);

                var lightStatusReport= CheckLightsOn(trainCar.Next, level);

                isLightBulbOn = lightStatusReport.IsLightOn;

                stepsTaken = lightStatusReport.StepsTaken;

                level++;
            }
            return level + stepsTaken;
        }

        public void WalkLeft(TrainCar trainCar, int steps)
        {
            trainCar.IsLightOn = true;

            for (int step = 1; step < steps; step++)
            {
                WalkLeft(trainCar.Next, steps - 1);
            }
        }

        public void WalkRight(TrainCar trainCar, int steps)
        {
            trainCar.IsLightOn = false;

            for (int step = 1; step < steps; step++)
            {
                WalkRight(trainCar.Previous, steps - 1);
            }
        }

        //count steps taken. + level.
        public LightStatusReport CheckLightsOn(TrainCar trainCar, int steps)
        {
            LightStatusReport lsr = new LightStatusReport() {IsLightOn = trainCar.IsLightOn, StepsTaken = 1};

            if (!trainCar.IsLightOn)
            {
                return lsr;
            }

            for (int step = 1; step < steps; step++)
            {
                lsr = CheckLightsOn(trainCar.Next, steps - 1);
                lsr.StepsTaken += step;
            }

            return lsr;
        }
    }

    public class LightStatusReport
    {
        public int StepsTaken { get; set; }

        public bool IsLightOn { get; set; }
    }

}
