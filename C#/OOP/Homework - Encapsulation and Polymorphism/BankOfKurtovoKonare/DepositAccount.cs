namespace BankOfKurtovoKonare
{
    using System;

    public class DepositAccount : Account, IWidrawable , IDepositable
    {
        public DepositAccount(Customer customer, decimal ballance, decimal interestRate)
            : base(customer, ballance, interestRate)
        {
            
        }

        public void Widraw(decimal ammount)
        {
            if (ammount <= 0)
            {
                throw new ArgumentOutOfRangeException("Ammount must be > 0 ");
            }

            this.Ballance -= ammount;
        }

        public override decimal CalculateInterest(decimal months)
        {
            if (this.Ballance > 0 && this.Ballance < 1000)
            {
                return 0M;
            }
           
            return base.CalculateInterest(months);
        }
    }
}
