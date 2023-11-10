using Lab6;

class Program
{
    public static void Main()
    {
        // ArraySort
        var rnd = new Random();

        var resultData = new Dictionary<string, double>() {
            {"BubbleSort", 0},
            {"ShakerSort", 0},
            {"InsertionSort", 0},
            {"QuickSort", 0}
        };

        var numberOfExecutions = 10;

        for (int i = 0; i < numberOfExecutions; i++)
        {
            var arrSort = new ArraySort(10 * rnd.Next(1, 1000));
            var rndArr = arrSort.GetRandomArray();
            arrSort.SetArray((int[])rndArr.Clone());

            // BubbleSort
            var time = GetExecutionTime(arrSort.BubbleSort);
            resultData["BubbleSort"] += time;
            arrSort.SetArray((int[])rndArr.Clone());

            // ShakerSort
            time = GetExecutionTime(arrSort.ShakerSort);
            resultData["ShakerSort"] += time;
            arrSort.SetArray((int[])rndArr.Clone());

            // InsertionSort
            time = GetExecutionTime(arrSort.InsertionSort);
            resultData["InsertionSort"] += time;
            arrSort.SetArray((int[])rndArr.Clone());

            // QuickSort
            time = GetExecutionTime(arrSort.QuickSort);
            resultData["QuickSort"] += time;
        }

        Console.WriteLine("Среднее время выполнения сортировок");
        foreach (var pair in resultData)
        {
            string key = pair.Key;
            double value = pair.Value;
            double average = value / numberOfExecutions;
            Console.WriteLine($"{key}: {average:f4}");
        }
        Console.WriteLine();

        // MyArray
        var my = new MyArray(2, 3);
        my.Print();
        my.Sort();
        my.Print("Sort:");
        my.Sort(false);
        my.Print("Sort(desc):");

        // StepArray
        var sa = new StepArray();
        sa.ReadValues();
        sa.Print();
        sa.GodMethod();
        sa.Print();
    }

    static double GetExecutionTime(Action function)
    {
        DateTime startTime = DateTime.Now;
        function.Invoke();
        DateTime endTime = DateTime.Now;
        return (endTime - startTime).TotalMilliseconds;
    }
}