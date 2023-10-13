using Helpers;

namespace Lab1
{
    public class Solutions
    {
        public static void Solution1()
        {
            double a = InputHelpers.ReadDouble("Введите число а (например, 1 или 2,5)");

            double d1 = 2 * a + Math.Pow(a, 2);
            double d2 = 2 * a - Math.Pow(a, 2);

            if (d1 == 0)
            {
                Console.WriteLine("Ответ: В резльтате вычеселений произошла ошибка деления на ноль\n");
                return;
            }

            if (d2 == 0)
            {
                Console.WriteLine("Ответ: В резльтате вычеселений произошла ошибка деления на ноль\n");
                return;
            }

            double z1 = Math.Pow((1 + a + Math.Pow(a, 2)) / d1 + 2 - ((1 - a + Math.Pow(a, 2)) / d2), -1) * (5 - 2 * Math.Pow(a, 2));
            double z2 = (4 - Math.Pow(a, 2)) / 2;

            Console.WriteLine($"Ответ: z1 = {z1}, z2 = {z2}\n");
        }

        public static void Solution2()
        {
            Console.WriteLine("Введите x (например 3 или -2,75): ");
            bool parsed = double.TryParse(Console.ReadLine(), out double x);

            if (!parsed)
            {
                Console.WriteLine("Вы ввели некорректное значение x");
                return;
            }

            double y;

            if (-7 > x || x > 3)
            {
                Console.WriteLine("Ответ: Функция не определена\n");
                return;
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

            Console.WriteLine($"Ответ: y = {y}\n");
        }

        public static void Solution3()
        {
            Console.WriteLine("Введите значение x: ");
            bool parsedX = double.TryParse(Console.ReadLine(), out double x);

            if (!parsedX)
            {
                Console.WriteLine("Вы ввели некорректное значение x");
                return;
            }

            Console.WriteLine("Введите значение y: ");

            bool parsedY = double.TryParse(Console.ReadLine(), out double y);

            if (!parsedY)
            {
                Console.WriteLine("Вы ввели некорректное значение y");
                return;
            }

            bool isOk = false;

            if (y >= Math.Pow(x - 2, 2) - 3)
            {
                if (y >= 0)
                    isOk = y <= x;
                else
                    isOk = y <= -x;
            }

            Console.WriteLine("Ответ: " + (isOk ? "Попали\n" : "Не попали\n"));
        }
    }
}