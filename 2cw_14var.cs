using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello students ;)";
            string[] tasks = { Task1(text), Task2(text) };

            Console.WriteLine(tasks[0]); // Вывод результата первой задачи

            Task3();

            JsonIO jsonIO = new JsonIO();
            jsonIO.HandleJsonFiles(text, tasks[0], tasks[1]);
        }

        // Задание 1:
        public static string Task1(string input)
        {
            int letters = 0, digits = 0, punctuation = 0, spaces = 0;

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    letters++;
                }
                else if (char.IsDigit(c))
                {
                    digits++;
                }
                else if (char.IsPunctuation(c))
                {
                    punctuation++;
                }
                else if (char.IsWhiteSpace(c))
                {
                    spaces++;
                }
            }

            return $"{letters}, {digits}, {punctuation}, {spaces}";
        }

        // Задание 2:
        public static string Task2(string input)
        {
            string result = "";
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result += ShiftLetter(c);
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        private static char ShiftLetter(char letter)
        {
            const string alphabetLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            const string alphabetUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            if (char.IsLower(letter))
            {
                int originalIndex = alphabetLower.IndexOf(letter);
                int newIndex = (originalIndex + 15) % alphabetLower.Length;
                return alphabetLower[newIndex];
            }
            else if (char.IsUpper(letter))
            {
                int originalIndex = alphabetUpper.IndexOf(letter);
                int newIndex = (originalIndex + 15) % alphabetUpper.Length;
                return alphabetUpper[newIndex];
            }
            return letter;
        }

        // Задание 3:
        public static void Task3()
        {
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string folderPath = Path.Combine(downloadsPath, "Загрузки", "Test");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath1 = Path.Combine(folderPath, "cw2_1.json");
            string filePath2 = Path.Combine(folderPath, "cw2_2.json");

            // Закомментировано создание файлов
            // if (!File.Exists(filePath1))
            // {
            //     File.Create(filePath1).Close();
            // }

            // if (!File.Exists(filePath2))
            // {
            //     File.Create(filePath2).Close();
            // }
        }
    }

    // Задание 4: Работа с JSON
    public class JsonIO
    {
        public void HandleJsonFiles(string input, string task1Output, string task2Output)
        {
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string folderPath = Path.Combine(downloadsPath, "Загрузки", "Test");
            string filePath = Path.Combine(folderPath, "data.json");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var data = new
            {
                Input = input,
                Task1Output = task1Output,
                Task2Output = task2Output
            };
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                var existingData = JsonConvert.DeserializeObject<object>(jsonData);
                Console.WriteLine(JsonConvert.SerializeObject(existingData, Formatting.Indented));
            }
            else
            {
                string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
        }
    }
}
