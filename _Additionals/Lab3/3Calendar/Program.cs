class Program
{
    public static void Main()
    {
        int year = 2015;

        Console.Write("Введите номер месяца: ");

        if (!int.TryParse(Console.ReadLine(), out int month) || month < 1 || month > 12)
        {
            Console.WriteLine("Неверный месяц");
            return;
        }

        var day = new DateTime(year, month, 1);
        var dayOfWeek = day.DayOfWeek == 0 ? 7 : (int)day.DayOfWeek;

        Console.WriteLine("Пн Вт Ср Чт Пт Сб Вс");
        for (int i = 0; i < dayOfWeek - 1; i++)
            Console.Write("   ");

        while (day.Month == month)
        {
            Console.Write($"{day.Day,2} ");
            if (day.DayOfWeek == DayOfWeek.Sunday)
                Console.WriteLine();

            day = day.AddDays(1);
        }
    }
}