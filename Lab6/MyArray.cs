namespace Lab6
{
    public class MyArray
    {
        private int[,] _array;
        private readonly int _m;
        private readonly int _n;
        private readonly int MIN_VALUE = -100;
        private readonly int MAX_VALUE = 100;

        public MyArray()
        {
        }

        public MyArray(int m, int n)
        {
            _array = new int[m, n];

            _m = m;
            _n = n;

            var random = new Random();
            for (int i = 0; i < _m; i++)
                for (int j = 0; j < _n; j++)
                    _array[i, j] = random.Next(MIN_VALUE, MAX_VALUE);
        }

        public void Sort(bool asc = true)
        {
            var columnSums = new int[_n];
            var columnOrder = new int[_n];

            for (int j = 0; j < _n; j++)
            {
                int sum = 0;
                for (int i = 0; i < _m; i++)
                    sum += _array[i, j];
                columnSums[j] = sum;
                columnOrder[j] = j;
            }

            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n - i - 1; j++)
                {
                    if ((asc && columnSums[j] > columnSums[j + 1]) || (!asc && columnSums[j] < columnSums[j + 1]))
                    {
                        (columnSums[j + 1], columnSums[j]) = (columnSums[j], columnSums[j + 1]);
                        (columnOrder[j + 1], columnOrder[j]) = (columnOrder[j], columnOrder[j + 1]);
                    }
                }
            }

            int[,] sortedArray = new int[_m, _n];
            for (int j = 0; j < _n; j++)
            {
                int columnIndex = columnOrder[j];
                for (int i = 0; i < _m; i++)
                    sortedArray[i, j] = _array[i, columnIndex];
            }

            _array = sortedArray;
        }

        public void Print(string prefix = "Matrix:")
        {
            Console.WriteLine(prefix);
            for (int i = 0; i < _m; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < _n; j++)
                    Console.Write(_array[i, j] + "\t");
                Console.WriteLine();
            }
        }
    }
}