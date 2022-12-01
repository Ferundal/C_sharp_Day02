using System;
using System.Data;

namespace d02_ex01.Tasks
{
    public record Task
    {
        public string Title { get; }
        public string Summary { get; }
        public DateTime DueDate { get; }
        public TaskPriority Priority { get; }
        public TaskType Type { get; }

        public TaskState State { get; private set; } = TaskState.New;

        public Task(string title, TaskType type, TaskPriority priority = TaskPriority.Normal,
            string summary = null, DateTime dueDate = default)
        {
            Title = title;
            Summary = summary;
            DueDate = dueDate;
            Priority = priority;
            Type = type;
        }

        public bool SetState(TaskState state)
        {
            if (state == State)
                return true;
            if (State != TaskState.New)
                return false;
            State = state;
            return true;
        }
    }
}