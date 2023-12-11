
namespace LastDop
{
    public class Storage
    {
        private static readonly Random random = new Random();
        private static readonly double MIN_DAMAGE = 0;
        private static readonly double MAX_DAMAGE = 0.5;

        private readonly List<Container> containers;
        private readonly int capacity;

        public Storage(int capacity, int keepingPrice)
        {
            this.capacity = capacity;
            KeepingPrice = keepingPrice;
            containers = new List<Container>(capacity);
        }

        public int KeepingPrice { get; }

        public int ContainersCount
        {
            get
            {
                return containers.Count;
            }
        }

        public bool TryAdd(Container container)
        {
            double damageCoeff = Lerp(MIN_DAMAGE, MAX_DAMAGE, random.NextDouble());

            container.SetDamageCoefficient(damageCoeff);
            double containerCost = container.TotalCost;

            if (KeepingPrice >= containerCost)
                return false;

            if (containers.Count == capacity)
                containers.RemoveAt(0);

            containers.Add(container);
            return true;
        }

        public void RemoveContainer(int index)
        {
            if (containers.Count == 0)
                return;

            if (index < 0 || index >= containers.Count)
                throw new Exception("Не удалось удалить контейнер");

            containers.RemoveAt(index);
        }

        public override string ToString()
        {
            string result = "";

            if (containers.Count == 0)
                return "На складе нет контейнеров...";

            int index = 1;

            foreach (var container in containers)
                result += $"{index++}. {container}\n";

            result = result.TrimEnd('\n');
            return result;
        }

        private static double Lerp(double a, double b, double t)
        {
            return a + (b - a) * t;
        }
    }
}