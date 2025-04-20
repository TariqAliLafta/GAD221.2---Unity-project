using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject instructionPanel;
    public string[] dialogueLines;

    private bool isPlayerNearby = false;
    private DialogueTrigger dialogueTrigger;

    void Start()
    {
        // Look for a DialogueTrigger on the same object
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            instructionPanel.SetActive(true);
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            instructionPanel.SetActive(false);
            isPlayerNearby = false;
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.T))
        {
            instructionPanel.SetActive(false);

            // Start dialogue, pass task triggers if available
            if (dialogueTrigger != null)
                DialogueManager.Instance.StartDialogue(dialogueLines, dialogueTrigger.taskTriggers);
            else
                DialogueManager.Instance.StartDialogue(dialogueLines);
        }
    }
}
