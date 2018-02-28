using System;

namespace Assignment5
{
    class Program
    {
        /// <summary>
        /// The Main function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create RollingDie app
            var rollindADie = new RollingADie();

            // Create TwoSixesInTheRow app
            var twoSixesInTheRow = new TwoSixesInTheRow();

            // Create FiveTossesNumber app
            var fiveTossesNumber = new FiveTossesNumber();

            // Add twoSixesInTheRow handler to MoreTwantyPoints
            rollindADie.TwoSixesInTheRow += twoSixesInTheRow.TwoSixes;

            // Add fiveTossesNumber handler to TwoSixesInTheRow
            rollindADie.MoreTwentyPoints += fiveTossesNumber.GotTwentyOrMorePoints;

            // Run the rolling
            rollindADie.Run();

            Console.Read();
        }
    }
}
