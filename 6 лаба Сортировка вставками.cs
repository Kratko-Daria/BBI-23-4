using System; // Импорт пространства имен System, содержащего базовые классы и структуры .NET 
using System.Collections.Generic; // Импорт пространства имен System.Collections.Generic для работы с коллекциями 

struct Student
{
    private string _name; // Приватное поле для хранения имени студента 
    private int _grade; // Приватное поле для хранения оценки студента 
    private int _missedClasses; // Приватное поле для хранения количества пропущенных занятий студента 

    public Student(string name, int grade, int missedClasses) // Конструктор
    {
        _name = name;
        _grade = grade;
        _missedClasses = missedClasses;
    }

    public void DisplayInfo() // Метод вывода информации о студенте
    {
        Console.WriteLine($"{_name} - Пропущено занятий: {_missedClasses}");
    }

    // Свойства для доступа к полям структуры
    public int Grade => _grade;
    public int MissedClasses => _missedClasses;
    public string Name => _name;
}

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student("Иванов Иван", 3, 5),
            new Student("Петров Петр", 2, 3),
            new Student("Сидорова Мария", 2, 7),
            new Student("Смирнова Анна", 5, 1),
        };

        Sort(students); // Сортировка студентов с помощью метода сортировки вставками

        Console.WriteLine("Отсортированный список студентов по количеству пропущенных занятий:");
        foreach (var student in students)
        {
            student.DisplayInfo();
        }
    }

    // Метод сортировки вставками
    static void Sort(List<Student> students)
    {
        for (int i = 1; i < students.Count; i++) // цикл от второго элемента до последнего в списке
        {
            Student current = students[i]; // текущий элемент для вставки
            int j = i - 1; // индекс предыдущего элемента
            while (j >= 0 && students[j].MissedClasses > current.MissedClasses) // цикл сдвига элементов (если текущий меньше предыдущего, то сдвиг вправо)
            {
                students[j + 1] = students[j]; // сдвиг элементов вправо на одну позицию
                j--; // уменьшение индекса для продолжения сдвига, если необходимо
            }
            students[j + 1] = current; // вставка текущего элемента на его новое место в отсортированной части списка
        }
    }
}
