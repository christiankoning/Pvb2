using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text Health;
    public Text Collectibles;
    public Player player;
    public Boss boss;
    public GameObject BossHUD;
    public Slider HealthBarSlider;

    void Start()
    {
        player = FindObjectOfType<Player>();
        BossHUD.SetActive(false);
    }

    void Update()
    {
        Health.text = player.Health + "";
        Collectibles.text = player.Collected + "/3";

        if(player.Collected == 3)
        {
            BossHUD.SetActive(true);
        }

        HealthBarSlider.value = boss.BossHealth;
    }
}
