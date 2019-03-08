using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    public GameObject PausePanel;
    public bool isPaused;

    void start()
    {
        isPaused = false;
    }

    void Update()
    {
        if (isPaused)
        {
            pauseGame(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            pauseGame(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            SwitchPause();
        }
    }

    void pauseGame(bool state)
    {
        if (state)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        PausePanel.SetActive(state);
    }

    public void SwitchPause()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
