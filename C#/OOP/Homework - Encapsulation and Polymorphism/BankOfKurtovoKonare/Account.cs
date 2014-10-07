namespace BankOfKurtovoKonare
{
    using System;

    public abstract class Account : IBankAccount, IDepositable
    {
        private Customer customer;
        private decimal ballance;
        private decimal interestRate;

        protected Account(Customer customer, decimal ballance, decimal interestRate)
        {
            this.ballance = ballance;
            this.customer = customer;
            this.interestRate = interestRate;
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }
        }

        public decimal Ballance
        {
            get
            {
                return this.ballance;

            }

            set
            {
                this.ballance = value;
                
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;

            }

            set
            {
                this.interestRate = value;
            }
        }

        public virtual decimal CalculateInterest(decimal months)
        {
            decimal interest = this.Ballance*(1M + this.InterestRate*months);

            return interest;
        }


        public void Deposit(decimal ammount)
        {
            if (ammount <= 0)
            {
                throw new ArgumentOutOfRangeException("Ammount must be > 0 ");
            }

            this.Ballance += ammount;
        }
    }
}
