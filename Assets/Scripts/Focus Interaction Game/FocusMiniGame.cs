using UnityEngine;
using TMPro;

public class FocusMiniGame : MonoBehaviour
{
    public TextMeshProUGUI focusText; // Assign in the Inspector
    public CanvasGroup canvasGroup; // Assign in the Inspector

    private int pressCount = 0;
    public int requiredPresses = 20; // How many times player must press Spacebar
    private bool isActive = false;

    void Start()
    {
        canvasGroup.alpha = 0; // Hide the panel initially
    }

    public void StartMiniGame()
    {
        pressCount = 0;
        isActive = true;
        canvasGroup.alpha = 1; // Show panel
    }

    void Update()
    {
        if (!isActive) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressCount++;
            focusText.text += "FOCUS! "; // Add "FOCUS!" each time
        }

        if (pressCount >= requiredPresses)
        {
            EndMiniGame();
        }
    }

    void EndMiniGame()
    {
        isActive = false;
        canvasGroup.alpha = 0; // Hide panel
        Time.timeScale = 1f; // Resume game
    }
}
