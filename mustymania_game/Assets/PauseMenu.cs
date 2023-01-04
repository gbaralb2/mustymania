using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //1f is normal game speed
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); //SetActive enables/disables gameObjects
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

}
