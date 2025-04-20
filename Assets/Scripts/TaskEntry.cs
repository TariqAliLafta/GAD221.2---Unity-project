using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskEntry : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public Image scratchOverlay; // Optional: image of scribble overlay

    public void SetTask(string text, bool isScratched)
    {
        taskText.text = text;

        if (scratchOverlay != null)
            scratchOverlay.gameObject.SetActive(isScratched);

  
    }
}
