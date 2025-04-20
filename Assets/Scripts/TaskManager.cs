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
        public string description;
        public string text => description; // Read-only property
        public bool isDistraction;
        public bool isCompleted;

        public GameObject uiObject;
        public Image scribbleOverlay;

        public Task(string description, GameObject uiObject, Image scribbleOverlay, bool isDistraction = false)
        {
            this.description = description;
            this.uiObject = uiObject;
            this.scribbleOverlay = scribbleOverlay;
            this.isDistraction = isDistraction;
            this.isCompleted = false;
        }
    }

    public GameObject taskUIPrefab;
    public Transform taskListContainer;

    private List<Task> taskList = new List<Task>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Add initial task on game start
        Debug.Log("Adding initial task...");
        AddTask("Go to grocery store and buy ingredients for meal", false);

    }

    public void AddTask(string description, bool scratchOutMain = true)
    {
        GameObject taskUI = Instantiate(taskUIPrefab, taskListContainer);
        TextMeshProUGUI taskText = taskUI.GetComponentInChildren<TextMeshProUGUI>();
        Image scribble = taskUI.transform.Find("ScratchOverlay").GetComponent<Image>();

        taskText.text = description;
        scribble.enabled = false;

        Task newTask = new Task(description, taskUI, scribble, false); // false = not a distraction by default

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
