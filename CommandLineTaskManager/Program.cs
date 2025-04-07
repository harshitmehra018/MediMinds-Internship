using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Task
{
    public string Description;
    public string Priority;
    public bool Completed;
}

class Program
{
    static List<Task> tasks = new List<Task>();
    const string fileName = "tasks.txt";

    static void Main()
    {
        LoadTasks();

        while (true)
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Save & Exit");    
            Console.Write("Select option: ");
            string choice = Console.ReadLine();

            if (choice == "1") AddTask();
            else if (choice == "2") ListTasks();
            else if (choice == "3") CompleteTask();
            else if (choice == "4") DeleteTask();
            else if (choice == "5") { SaveTasks(); break; }
            else Console.WriteLine("Invalid option!");
        }
    }

    static void AddTask()
    {
        Console.Write("Task description: ");
        string desc = Console.ReadLine();

        Console.Write("Priority (high, medium, low): ");
        string priority = Console.ReadLine().ToLower();

        tasks.Add(new Task { Description = desc, Priority = priority, Completed = false });
        Console.WriteLine("Task added!");
    }

    static void ListTasks()
    {
        var sorted = tasks.OrderBy(t => t.Completed).ThenBy(t => t.Priority);
        int i = 1;
        foreach (var task in sorted)
        {
            string status = task.Completed ? "[X]" : "[ ]";
            Console.WriteLine($"{i++}. {status} {task.Description} ({task.Priority})");
        }
    }

    static void CompleteTask()
    {
        ListTasks();
        Console.Write("Task number to complete: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].Completed = true;
            Console.WriteLine("Task marked as completed.");
        }
    }

    static void DeleteTask()
    {
        ListTasks();
        Console.Write("Task number to delete: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
            Console.WriteLine("Task deleted.");
        }
    }

    static void SaveTasks()
    {
        using (StreamWriter sw = new StreamWriter(fileName))
            foreach (var task in tasks)
                sw.WriteLine($"{task.Description}|{task.Priority}|{task.Completed}");
        Console.WriteLine("Tasks saved!");
    }

    static void LoadTasks()
    {
        if (!File.Exists(fileName)) return;

        foreach (var line in File.ReadAllLines(fileName))
        {
            var parts = line.Split('|');
            tasks.Add(new Task
            {
                Description = parts[0],
                Priority = parts[1],
                Completed = bool.Parse(parts[2])
            });
        }
    }
}
