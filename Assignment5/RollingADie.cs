using System;
using System.Collections.Generic;

namespace Assignment5
{
    /// <summary>
    /// The Rolling a Die app
    /// </summary>
    class RollingADie
    {
        // the rolling results list
        private readonly List<int> numbersInDie;

        // The randome number generator
        private readonly Random random;

        // The delegate type for handling events
        public delegate void Rolling();

        // The event to get more or equals twenty points in the rolling
        public event Rolling MoreTwentyPoints;

        // The event to get two sixes in the row 
        public event Rolling TwoSixesInTheRow;

        /// <summary>
        /// Creates new RollingADie instance
        /// </summary>
        public RollingADie()
        {
            this.numbersInDie = new List<int>();
            this.random = new Random(1);
        }

        /// <summary>
        /// Statr the rolling
        /// </summary>
        public void Run()
        {
            int numOfTimesGetTwoSixesInARow = 0;
            int sum = 0;

            for (int i = 0; i < 50; ++i)
            {
                // Add the die number to the list
                numbersInDie.Add(random.Next(1, 7));

                // Prints the die number
                Console.WriteLine(numbersInDie[i] + " ");
                if (i >= 4)
                {
                    for (int j = i; j > i - 5; --j)
                    {
                        sum += numbersInDie[j];
                    }
                }

                // If the sum of numbers is greater than or equal to 20
                if (sum >= 20 && this.MoreTwentyPoints != null)
                {
                    // Notify when th event triggered
                    this.MoreTwentyPoints.Invoke();

                }
                sum = 0;

                // If it's the first time when we roll a die than continue
                if (i == 0)
                {
                    continue;
                }

                // If we get 'two sixes in a row' and we have a subscriber 
                if (numbersInDie[i] == 6 && numbersInDie[i - 1] == 6 && this.TwoSixesInTheRow != null)
                {
                    // Notify when the event triggered
                    this.TwoSixesInTheRow.Invoke();
                    numOfTimesGetTwoSixesInARow++;
                }

            }

            // Print the number of times we get 'two sixes in a row'
            Console.WriteLine(numOfTimesGetTwoSixesInARow);
        }

    }
}
