var main = () =>
{
    // TODO: что в отчете писать, кроме кода?

    // Десятичный счетчик
    var minValue = 15;
    var maxValue = 20;
    var counter = new DecimalCounter(minValue, maxValue, maxValue - minValue);
    Console.WriteLine(counter.GetValue());
    counter.Increase(5);
    Console.WriteLine(counter.GetValue());
    counter.Increase(1);
    Console.WriteLine(counter.GetValue());
    counter.Decrease(5);
    Console.WriteLine(counter.GetValue());
    counter.Decrease(3);
    Console.WriteLine(counter.GetValue());

    // Многочлен
    var p1 = new Polynomial(1, 5, 6);
    Console.WriteLine(p1.GetSolution());
    var p2 = new Polynomial(1, -4, 4);
    Console.WriteLine(p2.GetSolution());
    var p3 = new Polynomial(1, 3, 9);
    Console.WriteLine(p3.GetSolution());
};

main();

class DecimalCounter
{
    private readonly int minValue;
    private readonly int maxValue;
    private int value;

    public DecimalCounter(int minValue, int maxValue, int value)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;

        if (value > maxValue)
            this.value = maxValue;
        else if (value < minValue)
            this.value = minValue;
        else
            this.value = value;
    }

    public void Increase(int incValue)
    {
        int newValue = value + incValue;
        if (newValue > maxValue)
            value = (newValue - maxValue) + minValue;
        else
            value = newValue;
    }

    public void Decrease(int decValue)
    {
        int newValue = value - decValue;
        if (newValue < minValue)
            value = maxValue - (minValue - newValue);
        else
            value = newValue;
    }

    public int GetValue()
    {
        return value;
    }
};

class Polynomial
{
    private readonly double a;
    private readonly double b;
    private readonly double c;

    public Polynomial(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public string GetSolution()
    {
        double discriminant = Math.Pow(b, 2) - 4 * a * c;

        if (discriminant > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            return $"Уравнение имеет два корня: x1 = {x1}, x2 = {x2}";
        }
        else if (discriminant == 0)
        {
            double x = -b / (2 * a);
            return $"Уравнение имеет один корень: x = {x}";
        }
        return "Уравнение не имеет корней";
    }
}