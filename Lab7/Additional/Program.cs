
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
        Dictionary<char, int> romanMap = new Dictionary<char, int>
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

        string[] romanSymbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        int[] arabicValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        string result = "";

        for (int i = 0; i < romanSymbols.Length; i++)
        {
            while (arabic >= arabicValues[i])
            {
                result += romanSymbols[i];
                arabic -= arabicValues[i];
            }
        }

        return result;
    }
}
