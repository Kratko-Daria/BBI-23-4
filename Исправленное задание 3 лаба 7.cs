using System;

namespace Level3
{
    abstract class Athlete
    {
        protected string _name;
        protected int _result;

        public Athlete(string name, int result)
        {
            _name = name;
            _result = result;
        }

        public abstract void Print();

        // Метод для сравнения результатов двух атлетов
        public bool IsBetterThan(Athlete other)
        {
            return _result > other._result;
        }
    }

    class SkierWomen : Athlete
    {
        public SkierWomen(string name, int result) : base(name, result) { }

        public override void Print()
        {
            Console.WriteLine($"{_name} (Woman): {_result}");
        }
    }

    class SkierMen : Athlete
    {
        public SkierMen(string name, int result) : base(name, result) { }

        public override void Print()
        {
            Console.WriteLine($"{_name} (Man): {_result}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SkierWomen[] groupAWomen = { new SkierWomen("Иванова", 9), new SkierWomen("Петрова", 4), new SkierWomen("Сидорова", 7), new SkierWomen("Козлова", 10) };
            SkierMen[] groupAMen = { new SkierMen("Романов", 6), new SkierMen("Сергеев", 5), new SkierMen("Андреев", 8), new SkierMen("Антонов", 9) };

            SkierWomen[] groupBWomen = { new SkierWomen("Федорова", 8), new SkierWomen("Михайлова", 6), new SkierWomen("Николаева", 5), new SkierWomen("Дмитриева", 7) };
            SkierMen[] groupBMen = { new SkierMen("Жуков", 7), new SkierMen("Григорьев", 6), new SkierMen("Тимофеев", 9), new SkierMen("Максимов", 8) };

            Console.WriteLine("Таблица результатов для лыжниц-1:");
            PrintResults(groupAWomen);

            Console.WriteLine("\nТаблица результатов для лыжников-1:");
            PrintResults(groupAMen);

            Console.WriteLine("\nТаблица результатов для лыжниц-2:");
            PrintResults(groupBWomen);

            Console.WriteLine("\nТаблица результатов для лыжников-2:");
            PrintResults(groupBMen);

            Console.WriteLine("\nОбщая таблица результатов для лыжниц:");
            PrintResults(Merge(groupAWomen, groupBWomen));

            Console.WriteLine("\nОбщая таблица результатов для лыжников:");
            PrintResults(Merge(groupAMen, groupBMen));

            Console.WriteLine("\nОбщая таблица результатов для всех участников:");
            Athlete[] allParticipants = MergeAll(groupAWomen, groupAMen, groupBWomen, groupBMen);
            PrintResults(allParticipants);
        }

        static void PrintResults(Athlete[] arr)
        {
            foreach (var participant in arr)
            {
                participant.Print();
            }
        }

        static Athlete[] Merge(Athlete[] arr1, Athlete[] arr2)
        {
            Athlete[] result = new Athlete[arr1.Length + arr2.Length];
            int i = 0, j = 0, k = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i].IsBetterThan(arr2[j]))
                {
                    result[k++] = arr1[i++];
                }
                else
                {
                    result[k++] = arr2[j++];
                }
            }
            while (i < arr1.Length)
            {
                result[k++] = arr1[i++];
            }
            while (j < arr2.Length)
            {
                result[k++] = arr2[j++];
            }
            return result;
        }

        static Athlete[] MergeAll(params Athlete[][] groups)
        {
            if (groups.Length == 0)
                return new Athlete[0];

            Athlete[] result = groups[0];
            for (int i = 1; i < groups.Length; i++)
            {
                result = Merge(result, groups[i]);
            }
            return result;
        }
    }
}


