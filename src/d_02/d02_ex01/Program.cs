using System;
using System.Collections.Generic;
using d02_ex01;
using d02_ex01.Tasks;
using Microsoft.VisualBasic;
using Task = d02_ex01.Tasks.Task;

string title = null;
string summary = null;
DateTime dueDate = default;
TaskPriority priority = default;
TaskType type = default;

var tasks = new List<Task>();

bool isActive = true;
while (isActive)
{
    var line = Console.ReadLine();
    switch (line)
    {
        case "add":
            if (!ReadNewTaskValues())
                Console.WriteLine("Input error. Check the input data and repeat the request.");
            tasks.Add(new Task(title, type, priority, summary, dueDate));
            break;
        case "list":
            if(tasks.Count < 1)
                Console.WriteLine("The task list is still empty.");
            else
                foreach (var task in tasks)
                    Console.WriteLine(task);
            break;
        case "done":
            Done();
            break;
        case "wontdo":
            Wontdo();
            break;
        case "q":
        case "quit":
            isActive = false;
            break;
        default:
            Console.WriteLine("Input error. Check the input data and repeat the request.");
            break;
    }
    if (!ReadNewTaskValues())
        InputError();
}

bool ReadNewTaskValues()
{
    Console.WriteLine("Enter a title");
    title = Console.ReadLine();
    if (string.IsNullOrEmpty(title))
        return false;
    Console.WriteLine("Enter a description");
    summary = Console.ReadLine();
    Console.WriteLine("Enter the deadline");
    var line = Console.ReadLine();
    DateTime.TryParse(line, out dueDate);
    Console.WriteLine("Enter the type");
    line = Console.ReadLine();
    if (!Enum.TryParse(line, out type))
        return false;
    Console.WriteLine("Assign the priority");
    line = Console.ReadLine();
    Enum.TryParse(line, out priority);
    return true;
}

bool Done()
{
    Console.WriteLine("Enter a title");
    var line = Console.ReadLine();
    foreach (var task in tasks)
    {
        if (task.Title == line)
        {
            if (!task.SetState(TaskState.Completed))
            {
                Console.WriteLine("Input error. Check the input data and repeat the request.");
                return false;
            }
            Console.WriteLine($"The task {task.Title} is completed!");
            return true;
        }
    }
    Console.WriteLine("Input error. The task with this title was not found.");
    return false;
}

bool Wontdo()
{
    Console.WriteLine("Enter a title");
    var line = Console.ReadLine();
    foreach (var task in tasks)
    {
        if (task.Title == line)
        {
            if (!task.SetState(TaskState.Irrelevant))
            {
                Console.WriteLine("Input error. Check the input data and repeat the request.");
                return false;
            }
            Console.WriteLine($"The task {task.Title} is no longer relevant!");
            return true;
        }
    }
    Console.WriteLine("Input error. The task with this title was not found.");
    return false;
}

void InputError()
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
}