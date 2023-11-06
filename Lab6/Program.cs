using Lab6;

// ArraySort
var arrSort = new ArraySort(5);
arrSort.ConsoleReadArray();
arrSort.PrintArray();
arrSort.BubbleSort();
arrSort.PrintArray();

arrSort.ConsoleReadArray();
arrSort.PrintArray();
arrSort.ShakerSort();
arrSort.PrintArray();

arrSort.ConsoleReadArray();
arrSort.PrintArray();
arrSort.InsertionSort();
arrSort.PrintArray();

arrSort.ConsoleReadArray();
arrSort.PrintArray();
arrSort.QuickSort();
arrSort.PrintArray();

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