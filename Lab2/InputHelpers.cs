
namespace Helpers
{
    public class InputHelpers
    {
        public static double ReadDouble(string message)
        {
            Console.WriteLine(message);
            bool parsed = double.TryParse(Console.ReadLine(), out double value);
            if (!parsed)
            {
                throw new InputParsedException("Вы ввели некорректное значение");
            }
            return value;
        }
    }

    public class InputParsedException : Exception
    {
        public InputParsedException(string message) : base(message) { }
    }
}