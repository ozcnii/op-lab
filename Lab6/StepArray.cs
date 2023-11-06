
namespace Lab6
{
    public class StepArray
    {
        private int[][] _array;
        private int _cols = 0;

        public void ReadValues()
        {
            Console.WriteLine("Введите количество строк");
            int rows = int.Parse(Console.ReadLine()!);
            _array = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введите количество элементов строки ${i + 1}");
                int elCount = int.Parse(Console.ReadLine()!);
                _array[i] = new int[elCount];
                _cols++;

                for (int j = 0; j < elCount; j++)
                {
                    Console.WriteLine($"Введите ${j + 1} элемент");
                    int el = int.Parse(Console.ReadLine()!);
                    _array[i][j] = el;
                }
            }
        }

        public void GodMethod()
        {
            var flatArray = Flat();
            Array.Sort(flatArray);
            var currIdx = 0;

            foreach (var row in _array)
                for (int i = 0; i < row.Length; i++)
                    row[i] = flatArray[currIdx];
        }

        private int[] Flat()
        {
            int[] flatArray = new int[_cols];
            int currIdx = 0;

            for (int i = 0; i < _cols; i++)
            {
                for (int j = 0; j < _array[i].Length; j++)
                {
                    flatArray[currIdx] = _array[i][j];
                    currIdx++;
                }
            }

            return flatArray;
        }

        public void Print()
        {
            for (int i = 0; i < _cols; i++)
            {
                Console.Write($"Строка {i + 1}: ");
                for (int j = 0; j < _array[i].Length; j++)
                {
                    Console.Write(_array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}