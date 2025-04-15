using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    private bool hasBeenShown = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasBeenShown)
        {
            tutorialPanel.SetActive(true);
            Time.timeScale = 0f; 
        }
    }

    private void Update()
    {
        if (tutorialPanel.activeSelf && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
        {
            tutorialPanel.SetActive(false);
            Time.timeScale = 1f; 
            hasBeenShown = true;
        }
    }
}