using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    [System.Serializable]
    public class Task
    {
        public string text;
        public bool isDistraction;
        public bool isCompleted = false;
    }

    public List<Task> tasks = new List<Task>();
    public TaskUIManager uiManager;

    void Awake()
    {
        Instance = this;

        // Add initial main task
        tasks.Add(new Task { text = "Go to grocery store and buy ingredients for meal", isDistraction = false });
    }

    public void AddTask(string text, bool isDistraction)
    {
        tasks.Add(new Task { text = text, isDistraction = isDistraction });
        UpdateTaskUI();
    }

    public void CompleteTask(string text)
    {
        var task = tasks.Find(t => t.text == text);
        if (task != null)
        {
            task.isCompleted = true;
            UpdateTaskUI();
        }
    }

    public void UpdateTaskUI()
    {
        uiManager.DisplayTasks(tasks);
    }
}
