using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskEntry : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public Image ScratchOverlay; // Optional: image of scribble overlay

    public void SetTask(string text, bool isScratched)
    {
        taskText.text = text;

        if (ScratchOverlay != null)
            ScratchOverlay.gameObject.SetActive(isScratched);

  
    }
}
