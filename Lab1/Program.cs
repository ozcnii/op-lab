// See https://aka.ms/new-console-template for more information

using Lab1;
using Menu;

var menuActions = new Dictionary<string, Action>{
    {"Расчет по двум формулам", Solutions.Solution1},
    {"Вычесление значения функции по заданному значению", Solutions.Solution2},
    {"Опредления попадания точки в заданную мишень", Solutions.Solution3}
};

Console.WriteLine("Лабораторная работа 1. Выполнил студент 6103 Фокин Евгений\n");

ConsoleMenu.Run(menuActions);