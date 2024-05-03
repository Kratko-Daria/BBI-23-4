// уровень 1 номер 5 исправленный
using System;
using System.Collections.Generic;
using System.Linq;

// Определение структуры Student
struct Student
{
    private string _name;
    private int _grade;
    private int _missedClasses;

    public Student(string name, int grade, int missedClasses)
    {
        _name = name;
        _grade = grade;
        _missedClasses = missedClasses;
    }

    // Метод для вывода информации о студенте
    public void DisplayInfo()
    {
        Console.WriteLine($"{_name} - Пропущено занятий: {_missedClasses}");
    }

    // Свойства для доступа к полям структуры
    public int Grade => _grade;
    public int MissedClasses => _missedClasses;
}

class Program
{
    static void Main(string[] args)
    {
        // Список студентов
        List<Student> students = new List<Student>
        {
            new Student("Иванов Иван", 3, 5),
            new Student("Петров Петр", 2, 3),
            new Student("Сидорова Мария", 2, 7),
            new Student("Смирнова Анна", 5, 1),
        };

        // Фильтрация неуспевающих студентов и сортировка по количеству пропущенных занятий
        var failingStudents = students.Where(s => s.Grade == 2)
                                       .OrderByDescending(s => s.MissedClasses)
                                       .ToList();

        Console.WriteLine("Список неуспевающих студентов (оценка «2»), отсортированный по количеству пропущенных занятий:");
        foreach (var student in failingStudents)
        {
            student.DisplayInfo();
        }
    }
}

// уровень 2 номер 2 исправленный
using System;
using System.Collections.Generic;
using System.Linq;

struct Team
{
    private string _name;
    private int _points;

    public Team(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public int Points
    {
        get { return _points; }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{_name} - Очки: {_points}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Список команд первой группы
        List<Team> groupOne = new List<Team>
        {
            new Team("Команда A1", 10),
            new Team("Команда A2", 12),
            new Team("Команда A3", 8),
            new Team("Команда A4", 15),
            new Team("Команда A5", 7),
            new Team("Команда A6", 13),
            new Team("Команда A7", 9),
            new Team("Команда A8", 11),
            new Team("Команда A9", 6),
            new Team("Команда A10", 14),
            new Team("Команда A11", 5),
            new Team("Команда A12", 16),
        };

        // Список команд второй группы
        List<Team> groupTwo = new List<Team>
        {
            new Team("Команда B1", 11),
            new Team("Команда B2", 9),
            new Team("Команда B3", 17),
            new Team("Команда B4", 8),
            new Team("Команда B5", 12),
            new Team("Команда B6", 7),
            new Team("Команда B7", 15),
            new Team("Команда B8", 10),
            new Team("Команда B9", 13),
            new Team("Команда B10", 6),
            new Team("Команда B11", 14),
            new Team("Команда B12", 18),
        };

        // Отбор 6 лучших команд из каждой группы
        var topTeamsFromGroupOne = groupOne.OrderByDescending(team => team.Points).Take(6).ToList();
        var topTeamsFromGroupTwo = groupTwo.OrderByDescending(team => team.Points).Take(6).ToList();

        // Объединение списков лучших команд обеих групп и сортировка итогового списка
        var teamsInSecondStage = topTeamsFromGroupOne
            .Concat(topTeamsFromGroupTwo)
            .OrderByDescending(team => team.Points)
            .ToList();

        Console.WriteLine("Команды, прошедшие во второй этап соревнований:");
        foreach (var team in teamsInSecondStage)
        {
            team.DisplayInfo();
        }
    }
}

// уровень 3 номер 4 исправленный
using System;
using System.Collections.Generic;
using System.Linq;

struct Skier
{
    private string _lastName;
    private TimeSpan _result; // Время, потраченное на дистанцию

    public Skier(string lastName, TimeSpan result)
    {
        _lastName = lastName;
        _result = result;
    }

    // Метод для вывода информации о лыжнике
    public void Display(int place)
    {
        Console.WriteLine($"{place}\t{_lastName}\t{_result}");
    }

    // Свойство для доступа к результату
    public TimeSpan Result => _result;
}

class Program
{
    static void Main()
    {
        // Группа A
        List<Skier> groupA = new List<Skier>
        {
            new Skier("Иванов", TimeSpan.FromSeconds(250.5)),
            new Skier("Петров", TimeSpan.FromSeconds(245.0)),
            new Skier("Грязнов", TimeSpan.FromSeconds(242.1)),
            new Skier("Смирнов", TimeSpan.FromSeconds(225.9)),
        };

        // Группа B
        List<Skier> groupB = new List<Skier>
        {
            new Skier("Сидоров", TimeSpan.FromSeconds(260.7)),
            new Skier("Алексеев", TimeSpan.FromSeconds(240.2)),
            new Skier("Миронов", TimeSpan.FromSeconds(230.2)),
            new Skier("Александров", TimeSpan.FromSeconds(220.5)),
        };


        // Сортировка каждой группы по результату
        groupA = groupA.OrderBy(skier => skier.Result).ToList();
        groupB = groupB.OrderBy(skier => skier.Result).ToList();

        Console.WriteLine("Результаты соревнований по лыжным гонкам");
        Console.WriteLine("Место\tФамилия\tВремя");

        Console.WriteLine("\nГруппа A");
        int place = 1;
        foreach (var skier in groupA)
        {
            skier.Display(place);
            place++;
        }

        Console.WriteLine("\nГруппа B");
        place = 1; // Сброс счетчика мест для группы B
        foreach (var skier in groupB)
        {
            skier.Display(place);
            place++;
        }
    }
}
