using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    [System.Serializable]
    public class Task
    {
        public string text;
        public string description;
        public bool isDistraction;
        public bool isCompleted;
        public GameObject uiObject;
        public Image scribbleOverlay;

        public Task(string text, bool isDistraction = false)
        {
            this.text = text;
            this.description = text; // Default description same as text
            this.isDistraction = isDistraction;
            this.isCompleted = false;
            this.uiObject = null;
            this.scribbleOverlay = null;
        }
    }

    public GameObject taskUIPrefab;
    public Transform taskListContainer;

    private List<Task> taskList = new List<Task>();

    private void Start()
    {
        // Add initial task on game start
        AddTask("Go to grocery store and buy ingredients for meal", false);
    }

    private void Awake()
    {
        Instance = this;
    }

    public void AddTask(string description, bool scratchOutMain = true)
    {
        GameObject taskUI = Instantiate(taskUIPrefab, taskListContainer);
        TextMeshProUGUI taskText = taskUI.GetComponentInChildren<TextMeshProUGUI>();
        Image scribble = taskUI.transform.Find("ScratchOverlay").GetComponent<Image>();

        taskText.text = description;
        scribble.enabled = false;

        Task newTask = new Task(description)
        {
            description = description,
            uiObject = taskUI,
            scribbleOverlay = scribble
        };

        taskList.Add(newTask);

        if (scratchOutMain)
            ScratchMainGoal(true);
    }

    public void CompleteTask(string description)
    {
        for (int i = 0; i < taskList.Count; i++)
        {
            if (taskList[i].description == description)
            {
                Destroy(taskList[i].uiObject);
                taskList.RemoveAt(i);
                break;
            }
        }

        if (!taskList.Exists(t => t.description != "Go to grocery store and buy ingredients for meal"))
        {
            ScratchMainGoal(false);
        }
    }

    private void ScratchMainGoal(bool scratch)
    {
        foreach (var task in taskList)
        {
            if (task.description == "Go to grocery store and buy ingredients for meal")
            {
                task.scribbleOverlay.enabled = scratch;
                break;
            }
        }
    }

    public List<Task> GetCurrentTasks()
    {
        return taskList;
    }
}
