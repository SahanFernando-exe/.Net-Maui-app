using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace task_app
{
    class Task
    {
        public string Title { get; set; }
        public string? Overview { get; set; }

        public string FilePath = FileSystem.Current.AppDataDirectory;

        public Task(string title, string? overview)
        {
            Title = title;
            Overview = overview;
        }

        public void save(string filePath)
        {
            var options = new JsonSerializerOptions {WriteIndented = true};
            string jsonString = JsonSerializer.Serialize(this, options);
            string fullPath = System.IO.Path.Combine(FilePath, "Data.txt");
            File.AppendAllText(fullPath, jsonString+",");
            Console.WriteLine(FileSystem.Current.AppDataDirectory);
        }

        public static List<Task>? allTasks()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = File.ReadAllText(System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "Data.txt"));
            return JsonSerializer.Deserialize<List<Task>>("[" + json.Remove(json.Length-1) + "]", options);
        }
    }
}
