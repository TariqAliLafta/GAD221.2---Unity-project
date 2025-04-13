using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private bool isDialogueOpen = false;

    private string[] lines = {
        "Hey there!",
        "This world is a little overwhelming, isn't it?",
        "Remember, you’ve got this!"
    };
    private int currentLine = 0;

    void Awake()
    {
        Instance = this;
    }

    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        currentLine = 0;
        dialogueText.text = lines[currentLine];
        isDialogueOpen = true;
    }

    void Update()
    {
        if (isDialogueOpen && Input.GetKeyDown(KeyCode.T))
        {
            currentLine++;
            if (currentLine < lines.Length)
            {
                dialogueText.text = lines[currentLine];
            }
            else
            {
                dialoguePanel.SetActive(false);
                isDialogueOpen = false;
            }
        }
    }
}
