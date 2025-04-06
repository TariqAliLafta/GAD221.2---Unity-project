using UnityEngine;

public class FocusTrigger : MonoBehaviour
{
    public FocusMiniGame focusMiniGame; // Reference the script instead of GameObject

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered focus zone!");

            if (focusMiniGame != null)
            {
                focusMiniGame.StartMiniGame();  // Call function properly
                Time.timeScale = 0f; // Pause game
                Debug.Log("Mini-game activated!");
            }
            else
            {
                Debug.LogError("Focus MiniGame script is NOT assigned in the Inspector!");
            }
        }
    }
}
