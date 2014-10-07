namespace BankOfKurtovoKonare
{
    using System;

    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal ballance, decimal interestRate)
            : base(customer, ballance, interestRate)
        {

        }

        public override decimal CalculateInterest(decimal months)
        {
            if (this.Customer is CompanyCustomer)
            {
                return base.CalculateInterest(months - 2);
            }
            else if (this.Customer is IndividualCustomer)
            {
                return base.CalculateInterest(months - 3);
            }
            else
            {
                throw new InvalidOperationException("Invalid Customer");
            }
        }
    }
}
