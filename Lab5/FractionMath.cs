namespace Lab5
{
    public class FractionMath
    {
        public static Fraction Add(Fraction first, Fraction second)
        {
            int numerator = first.GetNumerator() * second.GetDenominator() + first.GetDenominator() * second.GetNumerator();
            int denominator = first.GetDenominator() * second.GetDenominator();
            return new Fraction(numerator, denominator);
        }

        public static Fraction Sub(Fraction first, Fraction second)
        {
            int numerator = first.GetNumerator() * second.GetDenominator() - first.GetDenominator() * second.GetNumerator();
            int denominator = first.GetDenominator() * second.GetDenominator();
            return new Fraction(numerator, denominator);
        }

        public static Fraction Mul(Fraction first, Fraction second)
        {
            int numerator = first.GetNumerator() * second.GetNumerator();
            int denominator = first.GetDenominator() * second.GetDenominator();
            return new Fraction(numerator, denominator);
        }

        public static Fraction Div(Fraction first, Fraction second)
        {
            int numerator = first.GetNumerator() * second.GetDenominator();
            int denominator = first.GetDenominator() * second.GetNumerator();
            return new Fraction(numerator, denominator);
        }
    }
}