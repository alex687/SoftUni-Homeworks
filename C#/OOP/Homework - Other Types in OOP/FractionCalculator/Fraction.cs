namespace FractionCalculator
{
    using System;

    public struct Fraction
    {
        public Fraction(int numerator, int denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public int Numerator { get; set; }

        public int Denominator { get; set; }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int num = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
            int denom = f1.Denominator * f2.Denominator;

            return new Fraction(num, denom);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int num = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
            int denom = f1.Denominator * f2.Denominator;

            return new Fraction(num, denom);
        }

        public override string ToString()
        {
            return ((double)this.Numerator / (double)this.Denominator).ToString();
        }
    }
}
