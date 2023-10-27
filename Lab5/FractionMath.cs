namespace Lab5
{
    public class FractionMath
    {
        public static Fraction Add(Fraction first, Fraction second)
        {
            int numerator = first.Numerator * second.Denominator + first.Denominator * second.Numerator;
            int denominator = first.Denominator * second.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction Sub(Fraction first, Fraction second)
        {
            int numerator = first.Numerator * second.Denominator - first.Denominator * second.Numerator;
            int denominator = first.Denominator * second.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction Mul(Fraction first, Fraction second)
        {
            int numerator = first.Numerator * second.Numerator;
            int denominator = first.Denominator * second.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction Div(Fraction first, Fraction second)
        {
            int numerator = first.Numerator * second.Denominator;
            int denominator = first.Denominator * second.Numerator;
            return new Fraction(numerator, denominator);
        }
    }
}