using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public bool gamePaused;

    public void Pause()
    {
        if (gamePaused == true)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            gamePaused = false;
        }

        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            gamePaused = true;
        }
    }

    public void Unpause()
    {
    }
}
