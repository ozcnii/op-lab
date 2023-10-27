using Lab5;

var main = () =>
{
    Console.WriteLine("Введите числитель 1ой дроби:");
    int n1 = int.Parse(Console.ReadLine()!);
    Console.WriteLine("Введите знаменатель 1ой дроби:");
    int d1 = int.Parse(Console.ReadLine()!);

    Console.WriteLine("Введите числитель 2ой дроби:");
    int n2 = int.Parse(Console.ReadLine()!);
    Console.WriteLine("Введите знаменатель 2ой дроби:");
    int d2 = int.Parse(Console.ReadLine()!);

    try
    {
        var f1 = new Fraction(n1, d1);
        var f2 = new Fraction(n2, d2);
        Console.WriteLine("Дроби: ");
        f1.PrintInfo();
        f2.PrintInfo();

        Console.WriteLine("Сложение:");
        var f3 = FractionMath.Add(f1, f2);
        f3.PrintInfo();

        f3 = FractionMath.Sub(f1, f2);
        Console.WriteLine("Вычитание:");
        f3.PrintInfo();

        f3 = FractionMath.Mul(f1, f2);
        Console.WriteLine("Умножение:");
        f3.PrintInfo();

        f3 = FractionMath.Div(f1, f2);
        Console.WriteLine("Деление:");
        f3.PrintInfo();

        Console.WriteLine("Сокращение 1ой дроби:");
        f1.Reduce();
        f1.PrintInfo();
    }
    catch (DivideByZeroException err)
    {
        Console.WriteLine(err.Message);
    }
};

main();