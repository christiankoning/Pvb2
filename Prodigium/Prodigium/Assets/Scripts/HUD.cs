using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    public Text Health;
    public Text Collectibles;
    public Player player;
    public Boss boss;
    public GameObject BossHUD;
    public Slider HealthBarSlider;
    public GameObject InventoryPanel;
    private bool IsOpen;
    public PauseGame pause;

    void Start()
    {
        player = FindObjectOfType<Player>();
        BossHUD.SetActive(false);
        IsOpen = false;
    }

    void Update()
    {
        Health.text = player.Health + "";
        Collectibles.text = player.Collected + "/3";

        if(player.Collected == 3)
        {
            BossHUD.SetActive(true);
        }

        if (SceneManager.GetSceneByBuildIndex(2).isLoaded)
        {
            HealthBarSlider.value = boss.BossHealth;
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            Switch();
        }

        if(pause.isPaused == true)
        {
            IsOpen = false;
            InventoryPanel.SetActive(false);
        }
    }

    void Switch()
    {
        if (pause.isPaused == false)
        {
            if (IsOpen == true)
            {
                IsOpen = false;
                InventoryPanel.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                IsOpen = true;
                InventoryPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
