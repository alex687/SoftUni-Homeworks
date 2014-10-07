using System;


namespace BankOfKurtovoKonare
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer petar = new IndividualCustomer("Petar Gigov", "8412316466");
            Customer softUni = new CompanyCustomer("Software University", "BG25445644");

            Account petarDepositAccount = new DepositAccount(petar, 1000m, 3.0m);
            Console.WriteLine(petarDepositAccount.CalculateInterest(12).ToString("f2"));
            Console.WriteLine();

            Account petarLoanAccount = new LoanAccount(petar, 10000m, 12m);
            Console.WriteLine(petarLoanAccount.CalculateInterest(4).ToString("f2"));
            Account softuniLoanAccount = new LoanAccount(softUni, 10000m, 12m);
            Console.WriteLine(softuniLoanAccount.CalculateInterest(4).ToString("f2"));
            Console.WriteLine();

            Account petarMortgageAccount = new MortgageAccount(petar, 10000m, 12m);
            Console.WriteLine(petarMortgageAccount.CalculateInterest(12).ToString("f2"));
            Account softUniMortgageAccount = new MortgageAccount(softUni, 10000m, 12m);
            Console.WriteLine(softUniMortgageAccount.CalculateInterest(12).ToString("f2"));
            Console.WriteLine();
        }
    }
}
