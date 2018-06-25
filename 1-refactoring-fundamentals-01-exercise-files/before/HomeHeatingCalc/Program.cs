using System;
using System.Linq;

namespace HomeHeatingCalc
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Home Heating Cost Calculator...");
            Console.WriteLine("How many square feet is your home (1500 or 2500)?");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("How severe are your winters (Mild, moDerate, Severe)?");
            string w = Console.ReadLine();

            decimal cost = CalculateCost(size, w);
            Console.WriteLine("Cost: ${0}", cost);
            Console.ReadLine();
        }

        /// <summary>
        /// Calculates the cost to heat a home using this formula:
        /// http://www.travisindustries.com/CostOfHeating_WkSht.asp?P=2
        /// 
        /// </summary>
        /// <param name="p">The size of the home in square feet</param>
        /// <param name="c">Climate zones</param>
        /// <returns></returns>
        public static decimal CalculateCost(int p, string c)
        {
            // Mild winter
            if (c.Contains("M"))
            {
                return (decimal)p * 1000 * 0.12m * 293 / 1000000;
            }
            else
            {
                // Moderate winter
                if (c.Contains("D"))
                {
                    return (decimal)p * 2000 * 0.12m * 293 / 1000000;
                }
                else
                {
                    // Severe winter
                    if (p == 1500)
                    {
                        return (decimal)5000000 * 0.12m * 293 / 1000000;
                    }
                    else
                    {
                        return (decimal)8000000 * 0.12m * 293 / 1000000;

                    }
                }
            }
        }
    }
}
