using Lab7;
class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("1 - подсчет букв в строке");
            Console.WriteLine("2 - средняя длина слова");
            Console.WriteLine("3 - замена вхождений слова");
            Console.WriteLine("4 - подсчет вхождения строки");
            Console.WriteLine("5 - Проверка на палиндром");
            Console.WriteLine("0 - выход");

            string choose = Console.ReadLine()!;
            switch (choose)
            {
                case "1":
                    {
                        Console.WriteLine("введите строку");
                        string input = Console.ReadLine()!;
                        Console.WriteLine("букв в строке: " + Stringer.LettersCount(input));
                        break;
                    }

                case "2":
                    {
                        Console.WriteLine("введите строку");
                        string input = Console.ReadLine()!;
                        Console.WriteLine("средняя длина слова: " + Stringer.AverageWordCount(input));
                        break;
                    }

                case "3":
                    {

                        Console.WriteLine("введите строку");
                        string input = Console.ReadLine()!;
                        Console.WriteLine("введите слово, которое нужно заменить");
                        string oldValue = Console.ReadLine()!;
                        Console.WriteLine("введите слово, новое слово");
                        string newValue = Console.ReadLine()!;
                        Console.WriteLine("результирующая строка: ");
                        Console.WriteLine(Stringer.Replace(input, oldValue, newValue));
                        break;
                    }

                case "4":
                    {
                        Console.WriteLine("введите строку");
                        string input = Console.ReadLine()!;
                        Console.WriteLine("введите подстроку");
                        string substr = Console.ReadLine()!;
                        Console.WriteLine("количество подстрок: " + Stringer.CountSubstrings(input, substr));
                        break;
                    }

                case "5":
                    {
                        Console.WriteLine("введите строку");
                        string input = Console.ReadLine()!;
                        Console.WriteLine("строка палиндром :" + Stringer.IsPalindrom(input));
                        break;
                    }


                case "6":
                    {
                        Console.WriteLine("введите строку");
                        string input = Console.ReadLine()!;
                        Console.WriteLine("это дата :" + Stringer.IsDate(input));
                        break;
                    }

                case "0":
                    {
                        return;
                    }

                default:
                    {
                        Console.WriteLine("неверный ввод");
                        break;
                    }
            }

        }
    }
}