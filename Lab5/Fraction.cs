namespace Lab5
{
    public class Fraction
    {
        private int numerator;
        private int denominator;

        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return denominator;

            }
            set
            {
                if (value == 0)
                    throw new DivideByZeroException("Знаменатель не может быть равен нулю");
                denominator = value;
            }
        }

        public Fraction()
        {
            denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public void Add(Fraction fraction)
        {
            var result = FractionMath.Add(this, fraction);
            Numerator = result.Numerator;
            Denominator = result.Denominator;
        }

        public void Sub(Fraction fraction)
        {
            var result = FractionMath.Sub(this, fraction);
            Numerator = result.Numerator;
            Denominator = result.Denominator;
        }

        public void Mul(Fraction fraction)
        {
            var result = FractionMath.Mul(this, fraction);
            Numerator = result.Numerator;
            Denominator = result.Denominator;
        }

        public void Div(Fraction fraction)
        {
            var result = FractionMath.Div(this, fraction);
            Numerator = result.Numerator;
            Denominator = result.Denominator;
        }

        public void Reduce()
        {
            if (Numerator == 0)
                return;

            int gcd = GetGCD(Numerator, Denominator);

            Numerator /= gcd;
            Denominator /= gcd;
        }

        public void PrintInfo()
        {
            if (Numerator == 0)
                Console.WriteLine(0);
            else
                Console.WriteLine($"{Numerator}/{Denominator}");
        }

        public static Fraction operator +(Fraction first, Fraction second)
        {
            return FractionMath.Add(first, second);
        }

        public static Fraction operator -(Fraction first, Fraction second)
        {
            return FractionMath.Sub(first, second);
        }

        public static Fraction operator *(Fraction first, Fraction second)
        {
            return FractionMath.Mul(first, second);
        }

        public static Fraction operator /(Fraction first, Fraction second)
        {
            return FractionMath.Div(first, second);
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