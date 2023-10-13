namespace Lab2
{
    public class FirstLabSolutions
    {
        public static double? Solution2(double x)
        {
            double y;

            if (-7 > x || x > 3)
            {
                return null;
            }

            if (x <= -6)
                y = 2;
            else if (x <= -2)
                y = 0.25 * x + 0.5;
            else if (x <= 0)
                y = 2 - Math.Sqrt(-Math.Pow(x, 2) - 4 * x);
            else if (x <= 2)
                y = Math.Sqrt(4 - Math.Pow(x, 2));
            else
                y = -x + 2;

            return y;
        }

        public static bool Solution3(double x, double y)
        {

            bool isOk = false;

            if (y >= Math.Pow(x - 2, 2) - 3)
            {
                if (y >= 0)
                    isOk = y <= x;
                else
                    isOk = y <= -x;
            }

            return isOk;
        }
    }
}