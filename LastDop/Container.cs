namespace LastDop
{
    public class Container
    {
        private static readonly int MIN_CAPACITY = 10;
        private static readonly int MAX_CAPACITY = 101;

        private double boxesWeight;
        private double totalPrice;
        private double damageCoefficient = 1;
        private readonly List<Box> boxes = new();

        public Container()
        {
            var random = new Random();
            WeightCapacity = random.Next(MIN_CAPACITY, MAX_CAPACITY);
        }

        public int WeightCapacity { get; }
        public double TotalCost
        {
            get
            {
                double total = 0;
                foreach (var box in boxes)
                {
                    total += box.Price * box.Weight * (1.0 - damageCoefficient);
                }
                return Math.Round(total, 2);
            }
        }
        public double DamagedPercent
        {
            get
            {
                return Math.Round(damageCoefficient * 100, 2);
            }
        }

        public bool IsFull
        {
            get
            {
                return boxesWeight >= WeightCapacity;
            }
        }

        public bool TryAdd(Box box)
        {
            if (boxesWeight + box.Weight > WeightCapacity)
                return false;

            boxes.Add(box);
            boxesWeight += box.Weight;
            totalPrice += box.Weight * box.Price;
            return true;
        }

        public void SetDamageCoefficient(double coefficient)
        {
            damageCoefficient = coefficient;
        }

        public override string ToString()
        {
            return $"{boxes.Count} ящиков общей массой {boxesWeight}кг; Стоимость: {TotalCost}р";
        }
    }
}