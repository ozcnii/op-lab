namespace Lab6
{
    public class ArraySort
    {
        private readonly int _size;
        private int[] _value;

        public ArraySort()
        {
            _size = 0;
            _value = Array.Empty<int>();
        }

        public ArraySort(int size)
        {
            if (size < 0)
                throw new Exception("Размерность массива не может быть отрицтельной");
            _size = size;
            _value = new int[size];
        }

        public void ConsoleReadArray()
        {
            Console.WriteLine("Введите элементы массива через пробел");
            string arrayString = Console.ReadLine()!;
            var arr = arrayString.Split(" ");
            if (arr.Length > _size)
                throw new Exception("Количество элементов должно быть меньше или равно " + _size);
            _value = arr.Select(int.Parse).ToArray();
        }

        public void BubbleSort()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = i; i < _size; j++)
                {
                    if (_value[j] > _value[j + 1])
                    {
                        (_value[j + 1], _value[j]) = (_value[j], _value[j + 1]);
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
                    if (_value[i] > _value[i + 1])
                    {
                        (_value[i + 1], _value[i]) = (_value[i], _value[i + 1]);
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    if (_value[i] < _value[i - 1])
                    {
                        (_value[i - 1], _value[i]) = (_value[i], _value[i - 1]);
                    }
                }
                left++;
            }
        }

        public void InsertionSort()
        {
            for (int i = 1; i < _size; i++)
            {
                int key = _value[i];
                int j = i - 1;

                while (j >= 0 && _value[j] > key)
                {
                    _value[j + 1] = _value[j];
                    j--;
                }

                _value[j + 1] = key;
            }
        }

        public void QuickSort()
        {
            QuickSortImpl(0, _size);
        }

        public void QuickSortImpl(int low, int high)
        {
            if (low < high)
            {
                int pivot = _value[low];
                int left = low + 1;
                int right = high;

                while (left <= right)
                {
                    while (left <= right && _value[left] <= pivot)
                        left++;

                    while (_value[right] >= pivot && right >= left)
                        right--;

                    if (right >= left)
                        (_value[right], _value[left]) = (_value[left], _value[right]);
                }

                (_value[right], _value[low]) = (_value[low], _value[right]);

                QuickSortImpl(low, right - 1);
                QuickSortImpl(right + 1, high);
            }
        }

        public void PrintArray()
        {
            Console.Write("{ ");
            for (int i = 0; i < _size; i++)
            {
                Console.Write(_value[i]);
                if (i < _size - 1)
                    Console.Write(", ");
            }
            Console.WriteLine(" }");
        }
    }
}