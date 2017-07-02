using System;

namespace CircularTrackTwo
{
    public class MainClass
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
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
                            //a train should contain more than 1 car.
                            if (amount > 1)
                            {
                                var calculator = new CarCalculator();
                                calculator.Calculate(amount);
                                Console.WriteLine("The amount of cars is: " + calculator.CalculatedSize);
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

    /// <summary>
    /// Train Car.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Gets or sets the next car.
        /// </summary>
        /// <value>The next car.</value>
        public Car Next { get; set; }

        /// <summary>
        /// Gets or sets the previous car.
        /// </summary>
        /// <value>The previous.</value>
        public Car Previous { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CircularTrackTwo.Car"/> is light on.
        /// </summary>
        /// <value><c>true</c> if is light on; otherwise, <c>false</c>.</value>
        public bool IsLightOn { get; set; }

        /// <summary>
        /// Gets or sets the car number.
        /// For debugging purposes.
        /// </summary>
        /// <value>The number.</value>
        public int Number { get; set; }

        /// <summary>
        /// Adds the next car.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="nextCar">Next car.</param>
        public void Add(Car nextCar)
        {
            this.Next = nextCar;

            nextCar.Previous = this;
        }

        public Car(int number)
        {
            Number = number;
            IsLightOn = Convert.ToBoolean(new Random().Next(0, 1));
        }
    }

    /// <summary>
    /// Car calculator.
    /// </summary>
    public class CarCalculator
    {
        private int _calculatedSize = -1;

        public int CalculatedSize { get { return _calculatedSize; } }

        public Car InitTrain(int amount)
        {
            Car head = new Car(1);

            Car current = head;

            for (int index = 2; index < amount; index++)
            {
                Car nextCar = new Car(index);

                current.Add(nextCar);

                current = nextCar;
            }

            Car lastCar = new Car(amount);

            current.Add(lastCar);

            lastCar.Add(head);

            return head;
        }

        /// <summary>
        /// Calculate the specified amount.
        /// </summary>
        /// <returns>The calculate.</returns>
        /// <param name="amount">Amount.</param>
		public int Calculate(int amount)
        {
            Car head = InitTrain(amount);

            int result = GoForward(head);

            _calculatedSize = result;

            return result;
        }

        /// <summary>
        /// Goes forward.
        /// </summary>
        /// <returns>Number of steps.</returns>
        /// <param name="car">Car.</param>
        public int GoForward(Car car)
        {
            //turning the lights on;
            car.IsLightOn = true;

            bool foundLastCart = false;

            int steps = 0;

            Car current = car;

            while (!foundLastCart)
            {
                current = current.Next;

                steps++;

                if (current.IsLightOn && GoBack(current, steps))
                {
                    foundLastCart = true;
                }
                else
                {
                    current.IsLightOn = false;
                }
            }

            return steps;
        }

        /// <summary>
        /// Goes back.
        /// </summary>
        /// <returns>Returns whether the light was still on.</returns>
        /// <param name="car">Car.</param>
        /// <param name="steps">SNumber of steps back.</param>
        public bool GoBack(Car car, int steps)
        {
            Car current = car;

            for (int step = 0; step < steps; step ++)
            {
                current = current.Previous;
            }

            return current.IsLightOn;
        }
    }
}