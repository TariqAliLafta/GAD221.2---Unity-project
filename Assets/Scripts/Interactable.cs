using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject instructionPanel;
    public string[] dialogueLines;

    private bool isPlayerNearby = false;

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
            DialogueManager.Instance.StartDialogue(dialogueLines);
        }
    }
}
