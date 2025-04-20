using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TaskUIManager : MonoBehaviour
{
    public GameObject taskEntryPrefab;
    public Transform taskListParent;

    public void DisplayTasks(List<TaskManager.Task> tasks)
    {
        foreach (Transform child in taskListParent)
            Destroy(child.gameObject);

        foreach (var task in tasks)
        {
            if (task.isCompleted) continue;

            GameObject entryObj = Instantiate(taskEntryPrefab, taskListParent);
            TaskEntry entry = entryObj.GetComponent<TaskEntry>();

            bool scratchMainTask = ShouldScratchMainTask(tasks);

            bool isScratched = !task.isDistraction && scratchMainTask;
            entry.SetTask(task.text, isScratched);
        }
    }

    private bool ShouldScratchMainTask(List<TaskManager.Task> tasks)
    {
        // Scratch main task if distractions exist
        foreach (var task in tasks)
        {
            if (task.isDistraction && !task.isCompleted)
                return true;
        }
        return false;
    }
}
