using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    private string[] currentDialogue;
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

    public void StartDialogue(string[] lines)
    {
        currentDialogue = lines;
        currentLine = 0;
        dialoguePanel.SetActive(true);
        dialogueText.text = currentDialogue[currentLine];
        isDialogueOpen = true;
    }

    private void AdvanceDialogue()
    {
        currentLine++;
        if (currentLine < currentDialogue.Length)
        {
            dialogueText.text = currentDialogue[currentLine];
        }
        else
        {
            dialoguePanel.SetActive(false);
            isDialogueOpen = false;
        }
    }
}
