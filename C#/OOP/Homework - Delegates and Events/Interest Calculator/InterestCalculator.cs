namespace Interest_Calculator
{
    class InterestCalculator
    {
        public delegate double CalcInterest(double sum, double interest, double years);

        public double Result { get; private set; }

        public InterestCalculator(double money, double interest, double years, CalcInterest interestFunc)
        {
            this.Result = interestFunc(money, interest, years);
        }
    }
}
