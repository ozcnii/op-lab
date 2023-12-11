using LastDop;

class Program
{
    public static void Main()
    {
        StartMenu(
            new Dictionary<string, Action>
            {
                {"Создание склада", () => {
                    Console.WriteLine("Создание склада.");
                    Console.Write("Введите максимально допустимое число контейнеров на складе: ");
                    int capacity = int.Parse(Console.ReadLine()!);
                    Console.Write("Введите размер платы за хранение 1 контейнера: ");
                    int keepingPrice = int.Parse(Console.ReadLine()!);
                    var storage = new Storage(capacity, keepingPrice);

                    StartMenu(
                        new Dictionary<string, Action>
                        {
                            {"Показать контейнеры", () => {
                                Console.Clear();
                                Console.WriteLine(storage);
                            }},

                            {"Добавить контейнер", () => {
                                Console.Clear();

                                var container = new Container();
                                Console.WriteLine("Добавление контейнера.");
                                Console.WriteLine("Максимальная суммарная масса хранимых ящиков данного контейнера: " + container.WeightCapacity);

                                FillContainer(container);

                                bool wasAdded = storage.TryAdd(container);
                                Console.WriteLine($"Контейнер был повреждён на {container.DamagedPercent}%");

                                if (wasAdded)
                                {
                                    Console.WriteLine("Контейнер был успешно помещён на склад");
                                }
                                else
                                {
                                    Console.WriteLine($"Стоимость контейнера: {container.TotalCost}р");
                                    Console.WriteLine($"Цена за хранение контейнера: {storage.KeepingPrice}р");
                                    Console.WriteLine($"Цена за хранение превышает стоимость, поэтому контейнер не может быть помещён на склад.");
                                }

                            }},

                            {"Убрать контейнер", () => {
                                Console.Clear();
                                Console.WriteLine(storage);

                                if (storage.ContainersCount > 0)
                                {
                                    Console.Write("Введите номер контейнера, который хотите убрать: ");
                                    int containerNumber = int.Parse(Console.ReadLine()!);
                                    storage.RemoveContainer(containerNumber - 1);
                                    Console.WriteLine("Контейнер успешно был убран со склада.");
                                }
                            }}
                        }
                    );
                }}
            }
        );
    }

    private static void FillContainer(Container container)
    {
        Console.Write("Введите кол-во ящиков(натуральное число): ");
        int boxesCount = int.Parse(Console.ReadLine()!);
        for (int i = 1; i <= boxesCount; i++)
        {
            if (container.IsFull)
            {
                Console.WriteLine("Достигнута максимальная суммарная масса хранимых ящиков данного контейнера.");
                return;
            }

            Console.WriteLine($"Данные {i}-го ящика");
            Console.Write("Масса(кг): ");
            double weight = double.Parse(Console.ReadLine()!);
            Console.Write("Цена за кг: ");
            double price = double.Parse(Console.ReadLine()!);
            bool canBeAdded = container.TryAdd(new Box(weight, price));

            if (canBeAdded == false)
                Console.WriteLine("Такой ящик не залезет в контейнер");
        }
    }

    public static void StartMenu(Dictionary<string, Action> menuActions)
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
                catch (Exception err)
                {
                    Console.WriteLine("Ошибка: " + err.Message);
                }
            }
        }
    }
}