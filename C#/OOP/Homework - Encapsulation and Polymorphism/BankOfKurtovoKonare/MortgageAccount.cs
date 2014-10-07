namespace BankOfKurtovoKonare
{
    using System;

    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(Customer customer, decimal ballance, decimal interestRate)
            : base(customer, ballance, interestRate)
        {

        }

        public override decimal CalculateInterest(decimal months)
         {
            if (this.Customer is IndividualCustomer)
            {
                if (months >= 6)
                {
                    return base.CalculateInterest(months - 6);
                }
                else
                {
                    return this.Ballance;
                }
            }

            else if (this.Customer is CompanyCustomer)
            {
                if (months <= 12)
                {
                    return base.CalculateInterest(months)/2;
                }
                else
                {
                    return (base.CalculateInterest(12)/2) + base.CalculateInterest(months - 12);
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid Customer");

            }
         }
    }
}
