using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject instructionPanel; // assign in Inspector
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
            instructionPanel.SetActive(false); // hide the panel
            DialogueManager.Instance.StartDialogue(); // show dialogue instead
        }
    }
}
