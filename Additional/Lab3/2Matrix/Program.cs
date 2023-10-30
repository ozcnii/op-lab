public class Program
{
    public static void Main()
    {

        var rows = InputHelpers.ReadInt("Введите количество строк");
        var cols = InputHelpers.ReadInt("Введите количество колонок");

        var firstMatrix = InputHelpers.ReadIntMatrix(rows, cols);

        Menu(new Dictionary<string, Action>{
            {"Сложение матриц", () => {
                var rows = InputHelpers.ReadInt("Введите количество строк");
                var cols = InputHelpers.ReadInt("Введите количество колонок");
                var secondMatrix = InputHelpers.ReadIntMatrix(rows, cols);
                Console.WriteLine("\tСумма равна:");
                Matrix.Print(Matrix.Add(firstMatrix, secondMatrix), 1);
            }},

            {"Вычитание матриц", () => {
                var rows = InputHelpers.ReadInt("Введите количество строк");
                var cols = InputHelpers.ReadInt("Введите количество колонок");
                var secondMatrix = InputHelpers.ReadIntMatrix(rows, cols);
                Console.WriteLine("\tРазность равна:");
                Matrix.Print(Matrix.Subtract(firstMatrix, secondMatrix), 1);
            }},

            {"Умножение матриц", () => {
                var rows = InputHelpers.ReadInt("Введите количество строк");
                var cols = InputHelpers.ReadInt("Введите количество колонок");
                var secondMatrix = InputHelpers.ReadIntMatrix(rows, cols);
                Console.WriteLine("\tПроизведение равно:");
                Matrix.Print(Matrix.Multiply(firstMatrix, secondMatrix), 1);
            }},

            {"Умножение матрицы на число", () => {
                double num = InputHelpers.ReadDouble("Введите число, на которое умножить матрицу");
                Console.WriteLine("\tПроизведение равно:");
                Matrix.Print(Matrix.MultiplyByNum(firstMatrix, num), 1);
            }},

            {"Сравнение матриц", () => {
                var rows = InputHelpers.ReadInt("Введите количество строк");
                var cols = InputHelpers.ReadInt("Введите количество колонок");
                var secondMatrix = InputHelpers.ReadIntMatrix(rows, cols);
                bool isEqual = Matrix.Equals(firstMatrix, secondMatrix);
                if (isEqual)
                    Console.WriteLine("\tМатрицы равны");
                else
                    Console.WriteLine("\tМатрицы не равны");
            }},
        });
    }

    static void Menu(Dictionary<string, Action> menuActions)
    {
        while (true)
        {
            Console.WriteLine("Выберите один из пунтов меню");
            Console.WriteLine("0 - Осознанное завершение");

            for (int index = 0; index < menuActions.Count; index++)
            {
                var item = menuActions.ElementAt(index);
                Console.WriteLine($"{index + 1} - {item.Key}");
            }

            string menuAction = Console.ReadLine()!.Trim();
            bool parsed = int.TryParse(menuAction, out int actionIndex);

            if (!parsed || 0 > actionIndex || actionIndex > menuActions.Count)
            {
                Console.WriteLine("Не выбран ни один пункт меню\n");
                continue;
            }
            else if (actionIndex == 0)
                return;
            else
            {
                try
                {
                    menuActions.ElementAt(actionIndex - 1).Value();
                }
                catch (System.Exception err)
                {
                    Console.WriteLine("Произошла ошибка: " + err.Message);
                }
            }
        }
    }
}

class Matrix
{
    public static int[,] Add(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (rows1 != rows2 || cols1 != cols2)
            throw new Exception("Матрицы должны иметь одинаковую размерность");

        int[,] result = new int[rows1, cols1];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols1; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    public static int[,] Subtract(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (rows1 != rows2 || cols1 != cols2)
            throw new Exception("Матрицы должны иметь одинаковую размерность");

        int[,] result = new int[rows1, cols1];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols1; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }
    public static int[,] Multiply(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (cols1 != rows2)
        {
            throw new ArgumentException("Невозможно умножить матрицы с данными размерностями.");
        }

        int[,] result = new int[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }

    public static double[,] MultiplyByNum(int[,] matrix, double num)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * num;
            }
        }

        return result;
    }

    public static bool Equals(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (rows1 != rows2 || cols1 != cols2)
        {
            return false;
        }

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols1; j++)
            {
                if (matrix1[i, j] != matrix2[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static void Print<T>(T[,] matrix, int tabLevel = 0)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("".PadLeft(tabLevel * 8) + matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

class InputHelpers
{
    public static double ReadDouble(string message)
    {
        Console.WriteLine(message);
        bool parsed = double.TryParse(Console.ReadLine(), out double value);
        if (!parsed)
        {
            throw new Exception("Вы ввели некорректное значение");
        }
        return value;
    }

    public static int ReadInt(string message)
    {
        Console.WriteLine(message);
        bool parsed = int.TryParse(Console.ReadLine(), out int value);
        if (!parsed)
        {
            throw new Exception("Вы ввели некорректное значение");
        }
        return value;
    }

    public static int[,] ReadIntMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            Console.Write($"{i + 1} строка: ");
            var matrixRow = Console.ReadLine()!.Trim();
            var values = matrixRow.Split();

            for (int j = 0; j < cols; j++)
            {
                if (j < values.Length && int.TryParse(values[j], out matrix[i, j])) { }
                else
                    matrix[i, j] = 0;
            }
        }

        return matrix;
    }
}