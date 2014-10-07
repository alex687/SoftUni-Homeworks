namespace BankOfKurtovoKonare
{
    using System;

    class IndividualCustomer : Customer
    {
        private string ssn;

        public IndividualCustomer(string name, string ssn)
            : base(name)
        {
            this.SSN = ssn;
        }

        public string SSN
        {
            get
            {
                return this.ssn;
                
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("SSN cannot be null or empty");
                }

                this.ssn = value;
            }
        }
    }
}
