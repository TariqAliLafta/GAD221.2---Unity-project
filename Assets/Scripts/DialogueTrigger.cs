using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [System.Serializable]
    public class TaskTrigger
    {
        public int lineIndex;                // Which line triggers a task
        public string taskText;              // Text of the task
        public bool isDistraction;           // Is it a distraction?
    }

    public TaskTrigger[] taskTriggers;
}
