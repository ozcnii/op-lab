// See https://aka.ms/new-console-template for more information

using Lab2;
using Menu;

var menuActions = new Dictionary<string, Action>{
    {"Таблица значений функции", Solutions.Solution2},
    {"Серия выстрелов по мишени", Solutions.Solution3},
    {"Сумма ряда", Solutions.Solution4}
};

Console.WriteLine("Лабораторная работа 2. Выполнил студент 6103 Фокин Евгений\n");

ConsoleMenu.Run(menuActions);
