using Helpers;

namespace Lab2
{
    public class Solutions
    {
        public static void Solution2()
        {
            double xMin = InputHelpers.ReadDouble("Введите начало интервала");
            double xMax = InputHelpers.ReadDouble("Введите конец интервала");
            double dx = InputHelpers.ReadDouble("Введите шаг интервала");

            if (dx == 0)
            {
                Console.WriteLine("Шаг интервала не должен быть равен 0");
                return;
            }

            if (xMin > xMax && dx > 0)
            {
                Console.WriteLine("Шаг должен быть отрицтельным");
                return;
            }

            Console.WriteLine("\t\tx\t\t\ty");

            for (double x = xMin; x <= xMax; x += dx)
            {
                double? y = FirstLabSolutions.Solution2(x);

                if (y == null)
                {
                    Console.WriteLine("\t{0,11:0.00}\t{1,19:0.00}", x, "-");
                }
                else
                {
                    Console.WriteLine("\t{0,11:0.00}\t{1,19:0.00}", x, y);
                }
            }

        }

        public static void Solution3()
        {
            while (true)
            {
                try
                {
                    double x = InputHelpers.ReadDouble("Введите x");
                    double y = InputHelpers.ReadDouble("Введите y");

                    bool isHit = FirstLabSolutions.Solution3(x, y);
                    Console.WriteLine(isHit ? "Вы попали" : "Вы промахнулись");
                }
                catch (InputParsedException error)
                {
                    Console.WriteLine("Произошла ошибка: " + error.Message);
                }

                if (InputHelpers.ReadDouble("Хотите сделать следующий выстрел? (1 - да, 0 - нет)") == 0)
                {
                    return;
                }
            }
        }

        public static void Solution4()
        {
            double x = InputHelpers.ReadDouble("Введите значение x, которое больше 1");
            if (x <= 1)
            {
                Console.WriteLine("x должно быть больше 1");
                return;
            }

            double accuracy = InputHelpers.ReadDouble("Введите точность");

            int count = 0;
            double currentSum = Math.PI / 2;
            double nextSum;

            do
            {
                nextSum = Calc(x, count);
                currentSum += nextSum;
                count++;
            } while (Math.Abs(nextSum) > accuracy);

            Console.WriteLine("Сумма ряда = " + currentSum);
            Console.WriteLine("Количество членов ряда = " + count);
        }

        private static double Calc(double x, double n) => Math.Pow(-1, n + 1) / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
    }
}