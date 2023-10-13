using Helpers;

namespace Menu
{
    public class ConsoleMenu
    {
        private static bool isContinue = false;
        private static Action? lastAction = null;

        public static void Run(Dictionary<string, Action> menuActions)
        {
            while (true)
            {
                while (isContinue)
                {
                    Console.WriteLine("Повторить? (1 - да, 2 - выйти в меню, 0 - выйти полностью)");
                    var result = Console.ReadLine()?.Trim();

                    if (result == "1")
                    {
                        try
                        {
                            lastAction?.Invoke();
                        }
                        catch (InputParsedException error)
                        {

                            Console.WriteLine("Произошла ошибка: " + error.Message);
                        }
                    }
                    else if (result == "0")
                        return;
                    else
                    {
                        lastAction = null;
                        isContinue = false;
                    }
                }

                isContinue = true;

                Console.WriteLine("Выберите один из пунктов меню:");
                Console.WriteLine("0 - Выход");

                for (int index = 0; index < menuActions.Count; index++)
                {
                    var item = menuActions.ElementAt(index);
                    Console.WriteLine($"{index + 1} - {item.Key}");
                }

                string? solution = Console.ReadLine()?.Trim();
                bool parsed = int.TryParse(solution, out int solutionNum);

                if (!parsed || 0 > solutionNum || solutionNum > menuActions.Count)
                {
                    Console.WriteLine("Не выбран ни один пункт меню\n");
                    isContinue = false;
                }

                else if (solutionNum == 0)
                    return;
                else
                    lastAction = menuActions.ElementAt(solutionNum - 1).Value;

                try
                {
                    lastAction?.Invoke();
                }
                catch (InputParsedException error)
                {

                    Console.WriteLine("Произошла ошибка: " + error.Message);
                }
            }
        }
    }
}