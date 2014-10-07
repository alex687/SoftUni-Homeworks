namespace BankOfKurtovoKonare
{
    using System;

    public class CompanyCustomer : Customer
    {
        private string bulstat;

        public CompanyCustomer(string name, string bulstat)
            : base(name)
        {
            this.Bulstat = bulstat;
        }

        public string Bulstat
        {
            get
            {
                return this.bulstat;
                
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Bulstat cannot be null or empty");
                }

                this.bulstat = value;
            }
        }
    }
}

