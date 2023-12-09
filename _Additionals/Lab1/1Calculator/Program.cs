using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Введите выражение: ");
        string input = Console.ReadLine()!.Replace(" ", "");

        try
        {
            double result = Calculate(input);
            Console.WriteLine("Результат: " + result);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
    }

    static double Calculate(string expression)
    {
        string pattern = @"(\d+|\+|\-|\*|\/)";
        var matches = Regex.Matches(expression, pattern);
        var tokens = matches.Select(match => match.Value);

        var values = new Stack<double>();
        var operators = new Stack<string>();

        foreach (string token in tokens)
        {
            if ("+-*/".Contains(token))
            {
                while (operators.Count > 0 && IsHigherPrecedence(operators.Peek(), token))
                    ApplyOperator(operators, values);

                operators.Push(token);
            }
            else
                values.Push(double.Parse(token));
        }

        while (operators.Count > 0)

            ApplyOperator(operators, values);

        return values.Pop();
    }

    static bool IsHigherPrecedence(string op1, string op2)
    {
        return (op1 == "*" || op1 == "/") && (op2 == "+" || op2 == "-");
    }

    static void ApplyOperator(Stack<string> operators, Stack<double> values)
    {
        string op = operators.Pop();
        double right = values.Pop();
        double left = values.Pop();

        switch (op)
        {
            case "+":
                values.Push(left + right);
                break;
            case "-":
                values.Push(left - right);
                break;
            case "*":
                values.Push(left * right);
                break;
            case "/":
                if (right == 0)
                    throw new DivideByZeroException("Деление на ноль невозможно");
                values.Push(left / right);
                break;
        }
    }
}
