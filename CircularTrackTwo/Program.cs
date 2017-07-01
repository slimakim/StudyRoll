using System;

namespace CircularTrackTwo
{
    public delegate void Walk(Car car);

    public class MainClass
    {
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

    public class Car
    {
        public Car Next { get; set; }

        public Car Previous { get; set; }

        public bool IsLightOn { get; set; }

        public int Number { get; set; }

        public void Add(Car nextCar)
        {
            this.Next = nextCar;

            nextCar.Previous = this;
        }

        public Car(int number)
        {
            Number = number;
            IsLightOn = true;
        }
    }

    public class CarCalculator
    {
        private int _calculatedSize = -1;

        public int CalculatedSize { get { return _calculatedSize; }}

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

		public int Calculate(int amount)
		{
            Car head = InitTrain(amount);

			bool IsLightBulbChanged = false;

			int level = 1;

			int result = -1;

			while (!IsLightBulbChanged)
			{
				WalkLeft(head.Next, level);
				WalkRight(head.Previous, level);
				result = CheckLightBulbState(head, level);
				if (result > 0)
				{
					IsLightBulbChanged = true;
                    _calculatedSize = result;
				}
				level++;
			}

			return result;
		}
        public void WalkLeft(Car car, int level)
        {
            for (int i = 0; i < level; i++)
            {
                car.IsLightOn = true;
                car = car.Next;
            }
        }

        public void WalkRight(Car car, int level)
        {
			for (int i = 0; i < level; i++)
			{
                car.IsLightOn = false;
				car = car.Previous;
			}
        }

        public int CheckLightBulbState(Car car, int level)
        {
            for (int i = 0; i < level; i++)
			{
                if (!car.IsLightOn)
                {
                    return level + i;
                }

                car = car.Next;
			}

            return -1;
            
        }
    }


}