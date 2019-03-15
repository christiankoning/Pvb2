using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject TutorialPanel;
    public GameObject Page1;
    public GameObject Page2;
    public PauseGame pause;

    void Start()
    {
        TutorialPanel.SetActive(true);
        Page1.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pause.enabled = false;
    }

    public void Next()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
    }

    public void Previous()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
    }

    public void Done()
    {
        TutorialPanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pause.enabled = true;
    }

}
