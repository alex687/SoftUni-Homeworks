using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest_Calculator
{
    class Program
    {

        public static double GetSimpleInterest(double sum, double interest, double years)
        {
            return  (sum * (1 + (interest/100) * years));
        }

        public static double GetCompoundInterest(double sum, double interest, double years)
        {
            return sum * Math.Pow((1 + (interest /100) / 12), years * 12 );
        }

        static void Main(string[] args)
        {
            var compoundInterest = new InterestCalculator(500, 5.6, 10, GetCompoundInterest);
            var simpleInterest = new InterestCalculator(2500, 7.2, 15, GetSimpleInterest);

            Console.WriteLine("{0:F4}", compoundInterest.Result);
            Console.WriteLine("{0:F4}", simpleInterest.Result);
        }
    }
}
