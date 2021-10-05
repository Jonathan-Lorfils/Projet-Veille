using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private GameObject optionMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void ResumeGame()
    {
        pauseMenu.SetActive(false);
        optionMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    private void PauseGame()
    {
     pauseMenu.SetActive(true);
     Time.timeScale = 0f;
     Paused = true;
    }
}
