namespace Lab6
{
    public class ArraySort
    {
        private readonly int _size;
        private int[] _array;

        public ArraySort()
        {
            _size = 0;
            _array = Array.Empty<int>();
        }

        public ArraySort(int size)
        {
            if (size < 0)
                throw new Exception("Размерность массива не может быть отрицтельной");
            _size = size;
            _array = new int[size];
        }

        public int[] GetRandomArray(int minValue = -100, int maxValue = 100)
        {
            var array = new int[_size];
            var random = new Random();

            if (minValue > maxValue)
                (minValue, maxValue) = (maxValue, minValue);

            for (int i = 0; i < _size; i++)
                array[i] = random.Next(minValue, maxValue);

            return array;
        }

        public void SetArray(int[] value)
        {
            _array = value;
        }

        public void ConsoleReadArray()
        {
            Console.WriteLine("Введите элементы массива через пробел");
            string arrayString = Console.ReadLine()!;
            var arr = arrayString.Split(" ");
            if (arr.Length > _size)
                throw new Exception("Количество элементов должно быть меньше или равно " + _size);
            _array = arr.Select(int.Parse).ToArray();
        }

        public void BubbleSort()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size - i - 1; j++)
                {
                    if (_array[j] > _array[j + 1])
                    {
                        (_array[j + 1], _array[j]) = (_array[j], _array[j + 1]);
                    }
                }
            }
        }

        public void ShakerSort()
        {
            int left = 0;
            int right = _size - 1;
            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (_array[i] > _array[i + 1])
                    {
                        (_array[i + 1], _array[i]) = (_array[i], _array[i + 1]);
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    if (_array[i] < _array[i - 1])
                    {
                        (_array[i - 1], _array[i]) = (_array[i], _array[i - 1]);
                    }
                }
                left++;
            }
        }

        public void InsertionSort()
        {
            for (int i = 1; i < _size; i++)
            {
                int key = _array[i];
                int j = i - 1;

                while (j >= 0 && _array[j] > key)
                {
                    _array[j + 1] = _array[j];
                    j--;
                }

                _array[j + 1] = key;
            }
        }

        public void QuickSort()
        {
            QuickSortImpl(0, _size - 1);
        }

        private void QuickSortImpl(int low, int high)
        {
            if (low < high)
            {
                int pivot = _array[low];
                int left = low + 1;
                int right = high;

                while (left <= right)
                {
                    while (left <= right && _array[left] <= pivot)
                        left++;

                    while (_array[right] >= pivot && right >= left)
                        right--;

                    if (right >= left)
                        (_array[right], _array[left]) = (_array[left], _array[right]);
                }

                (_array[right], _array[low]) = (_array[low], _array[right]);

                QuickSortImpl(low, right - 1);
                QuickSortImpl(right + 1, high);
            }
        }

        public void PrintArray()
        {
            Console.Write("{ ");
            for (int i = 0; i < _size; i++)
            {
                Console.Write(_array[i]);
                if (i < _size - 1)
                    Console.Write(", ");
            }
            Console.WriteLine(" }");
        }
    }
}