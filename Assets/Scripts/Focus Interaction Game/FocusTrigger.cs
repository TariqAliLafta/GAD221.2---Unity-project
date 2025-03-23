using UnityEngine;

public class FocusTrigger : MonoBehaviour
{
    public GameObject focusMiniGame; // Assign the FocusPanel in the Inspector

    private void OnTriggerEnter2D(Collider2D other)  // Change to Collider for 3D
    {
        if (other.CompareTag("Player"))
        {
            focusMiniGame.SetActive(true);  // Show the mini-game
            Time.timeScale = 0f; // Pause game
        }
    }
}
