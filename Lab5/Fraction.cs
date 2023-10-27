namespace Lab5
{
    public class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction()
        {
            denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            SetNumerator(numerator);
            SetDenominator(denominator);
        }

        public int GetNumerator()
        {
            return numerator;
        }

        public int GetDenominator()
        {
            return denominator;
        }

        public void SetNumerator(int value)
        {
            numerator = value;
        }

        public void SetDenominator(int value)
        {
            if (value == 0)
                throw new DivideByZeroException("Знаменатель не может быть равен нулю");

            denominator = value;
        }

        public void Add(Fraction fraction)
        {
            var result = FractionMath.Add(this, fraction);
            SetNumerator(result.GetNumerator());
            SetDenominator(result.GetDenominator());
        }

        public void Sub(Fraction fraction)
        {
            var result = FractionMath.Sub(this, fraction);
            SetNumerator(result.GetNumerator());
            SetDenominator(result.GetDenominator());
        }

        public void Mul(Fraction fraction)
        {
            var result = FractionMath.Mul(this, fraction);
            SetNumerator(result.GetNumerator());
            SetDenominator(result.GetDenominator());
        }

        public void Div(Fraction fraction)
        {
            var result = FractionMath.Div(this, fraction);
            SetNumerator(result.GetNumerator());
            SetDenominator(result.GetDenominator());
        }

        public void Reduce()
        {
            if (numerator == 0)
                return;

            int gcd = GetGCD(numerator, denominator);

            numerator /= gcd;
            denominator /= gcd;
        }

        public void PrintInfo()
        {
            if (numerator == 0)
                Console.WriteLine(0);
            else
                Console.WriteLine($"{numerator}/{denominator}");
        }

        public static Fraction operator +(Fraction first, Fraction second)
        {
            return FractionMath.Add(first, second);
        }

        public static Fraction operator -(Fraction first, Fraction second)
        {
            return FractionMath.Add(first, second);
        }

        public static Fraction operator *(Fraction first, Fraction second)
        {
            return FractionMath.Add(first, second);
        }

        public static Fraction operator /(Fraction first, Fraction second)
        {
            return FractionMath.Add(first, second);
        }

        private static int GetGCD(int a, int b)
        {
            if (a == 0)
                return b;
            else
            {
                while (b != 0)
                {
                    if (a > b)
                        a -= b;
                    else
                        b -= a;
                }
                return a;
            }
        }
    }
}