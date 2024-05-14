// уровень 1 номер 5
using System;
using System.Collections.Generic;

namespace Level1
{
    abstract class Subject
    {
        protected List<Student> _students = new List<Student>();

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public abstract void PrintStudents();
    }

    class ComputerScience : Subject
    {
        public override void PrintStudents()
        {
            Console.WriteLine("Студенты по информатике:");
            foreach (var student in _students)
            {
                student.Print();
            }
        }
    }

    class Mathematics : Subject
    {
        public override void PrintStudents()
        {
            Console.WriteLine("Студенты по математике:");
            foreach (var student in _students)
            {
                student.Print();
            }
        }
    }

    class Student
    {
        private string _name;
        private int _mark;
        private int _missed;

        public Student(string name, int mark, int missed)
        {
            _name = name;
            _mark = mark;
            _missed = missed;
        }

        public void Print()
        {
            Console.WriteLine($"{_name} - оценка: {_mark}, пропущенных занятий: {_missed}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var computerScience = new ComputerScience();
            computerScience.AddStudent(new Student("Иванов", 5, 3));
            computerScience.AddStudent(new Student("Петров", 2, 17));

            var mathematics = new Mathematics();
            mathematics.AddStudent(new Student("Сидоров", 3, 6));
            mathematics.AddStudent(new Student("Козлов", 2, 9));

            computerScience.PrintStudents();
            mathematics.PrintStudents();
        }
    }
}

// уровень 2 номер 1
using System;

namespace Level2
{
    internal class Program
    {
        abstract class Person
        {
            protected string _name;

            public Person(string name)
            {
                _name = name;
            }

            public string GetName()
            {
                return _name;
            }

            public abstract void Print();
        }

        class Human : Person
        {
            public Human(string name) : base(name) { }

            public override void Print()
            {
                // Реализация абстрактного метода
                Console.WriteLine(GetName());
            }
        }

        class Student : Person
        {
            private static int nextStudentId = 1001;
            public int studentID { get; private set; }
            private double[] _results;

            public Student(string name, double[] results) : base(name)
            {
                _results = results;
                studentID = nextStudentId++;
            }

            public int GetStudentID()
            {
                return studentID;
            }

            public double[] GetResults()
            {
                return _results;
            }

            public virtual double CalculateAverage()
            {
                return (_results[0] + _results[1] + _results[2] + _results[3]) / 4;
            }

            public override void Print()
            {
                Console.WriteLine($"{GetName()}: {studentID} - {CalculateAverage()}");
            }
        }

        static void Main(string[] args)
        {
            Student[] students = { new Student("Иванов", new double[] { 3, 5, 5, 4 }), new Student("Петров", new double[] { 3, 5, 4, 4 }),
                new Student("Сидоров", new double[] { 5, 4, 5, 5 }), new Student("Козлов", new double[] { 3, 3, 3, 4 }),
                new Student("Викторов", new double[] { 3, 4, 3, 3 }), new Student("Макаров", new double[] { 3, 4, 5, 5 })};

            Sort(students);
            Console.WriteLine("ФИО: № студ. билета - оценка");
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].CalculateAverage() >= 4)
                {
                    students[i].Print();
                }
            }
        }

        static void Sort(Student[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length; j++)
                {
                    if (arr[j].CalculateAverage() > arr[j - 1].CalculateAverage())
                    {
                        Student temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
        }
    }
}

// уровень 3 номер 4
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
