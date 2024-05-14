using System;

namespace Level2
{
    internal class Program
    {
        abstract class Person
        {
            protected string _name;

            protected Person(string name)
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

            private static void QuickSort(Student[] arr, int left, int right)
            {
                int i = left, j = right;
                double pivot = arr[(left + right) / 2].CalculateAverage();

                while (i <= j)
                {
                    while (arr[i].CalculateAverage() > pivot) i++;
                    while (arr[j].CalculateAverage() < pivot) j--;
                    if (i <= j)
                    {
                        Student tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                        i++;
                        j--;
                    }
                }

                if (left < j) QuickSort(arr, left, j);
                if (i < right) QuickSort(arr, i, right);
            }

            public static void Sort(Student[] arr)
            {
                QuickSort(arr, 0, arr.Length - 1);
            }
        }

        static void Main(string[] args)
        {
            Student[] students = { new Student("Иванов", new double[] { 3, 5, 5, 4 }), new Student("Петров", new double[] { 3, 5, 4, 4 }),
                new Student("Сидоров", new double[] { 5, 4, 5, 5 }), new Student("Козлов", new double[] { 3, 3, 3, 4 }),
                new Student("Викторов", new double[] { 3, 4, 3, 3 }), new Student("Макаров", new double[] { 3, 4, 5, 5 })};

            Student.Sort(students);
            Console.WriteLine("ФИО: № студ. билета - оценка");
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].CalculateAverage() >= 4)
                {
                    students[i].Print();
                }
            }
        }
    }
}
