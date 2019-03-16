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

    public bool isFadingOut;
    public Texture2D fadeImage;
    public float fadeSpeed = 0.2f;
    public int drawDepth = 1000;
    private float alpha = -1.0f;
    private int fadeDir = 1;

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

        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Switch();
        }

        if(pause.isPaused == true)
        {
            IsOpen = false;
            InventoryPanel.SetActive(false);
        }
    }

    void OnGUI()
    {
        if (isFadingOut == true)
        {
            StartCoroutine(finalcountdown());
            alpha += fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            Color thisAlpha = GUI.color;
            thisAlpha.a = alpha;
            GUI.color = thisAlpha;

            GUI.depth = drawDepth;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeImage);
        }
    }

    IEnumerator finalcountdown()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main Menu");
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
