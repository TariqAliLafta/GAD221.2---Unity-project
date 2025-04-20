using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    private string[] currentDialogue;
    private DialogueTrigger.TaskTrigger[] currentTaskTriggers;

    private int currentLine;
    private bool isDialogueOpen = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isDialogueOpen)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                AdvanceDialogue();
            }
        }
    }

    public void StartDialogue(string[] lines, DialogueTrigger.TaskTrigger[] taskTriggers = null)
    {
        currentDialogue = lines;
        currentTaskTriggers = taskTriggers;
        currentLine = 0;
        dialoguePanel.SetActive(true);
        dialogueText.text = currentDialogue[currentLine];
        isDialogueOpen = true;

        CheckTaskTrigger();  // Check if line 0 triggers anything
    }

    private void AdvanceDialogue()
    {
        currentLine++;
        if (currentLine < currentDialogue.Length)
        {
            dialogueText.text = currentDialogue[currentLine];
            CheckTaskTrigger();  // See if this line has a task
        }
        else
        {
            dialoguePanel.SetActive(false);
            isDialogueOpen = false;
        }
    }

    private void CheckTaskTrigger()
    {
        if (currentTaskTriggers == null) return;

        foreach (var task in currentTaskTriggers)
        {
            if (task.lineIndex == currentLine)
            {
                TaskManager.Instance.AddTask(task.taskText, true);
            }
        }
    }
}
