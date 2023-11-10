
class Program
{
    static void Main()
    {
        Console.Write("Введите первое римское число: ");
        string romanNumeral1 = Console.ReadLine()!.ToUpper();

        Console.Write("Введите второе римское число: ");
        string romanNumeral2 = Console.ReadLine()!.ToUpper();

        Console.WriteLine("Выберите операцию:");
        Console.WriteLine("1. Сложение");
        Console.WriteLine("2. Вычитание");
        Console.WriteLine("3. Умножение");
        Console.WriteLine("4. Деление");

        string operation = Console.ReadLine()!;
        Console.WriteLine();

        int arabicNum1 = RomanToArabic(romanNumeral1);
        int arabicNum2 = RomanToArabic(romanNumeral2);
        int result = 0;

        switch (operation)
        {
            case "1":
                result = arabicNum1 + arabicNum2;
                break;
            case "2":
                result = arabicNum1 - arabicNum2;
                break;
            case "3":
                result = arabicNum1 * arabicNum2;
                break;
            case "4":
                result = arabicNum1 / arabicNum2;
                break;
            default:
                Console.WriteLine("Неверный выбор операции.");
                return;
        }

        Console.WriteLine($"Результат операции: {ArabicToRoman(result)}");
    }

    static int RomanToArabic(string roman)
    {
        var romanMap = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int result = 0;

        for (int i = 0; i < roman.Length; i++)
        {
            if (i + 1 < roman.Length && romanMap[roman[i]] < romanMap[roman[i + 1]])
            {
                result -= romanMap[roman[i]];
            }
            else
            {
                result += romanMap[roman[i]];
            }
        }

        return result;
    }

    static string ArabicToRoman(int arabic)
    {
        if (arabic < 1 || arabic > 3999)
        {
            throw new ArgumentOutOfRangeException("Входное число должно быть в пределах от 1 до 3999");
        }

        var romanMap = new Dictionary<int, string>
        {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };

        string result = "";

        foreach (var kvp in romanMap)
        {
            while (arabic >= kvp.Key)
            {
                result += kvp.Value;
                arabic -= kvp.Key;
            }
        }

        return result;
    }

}
