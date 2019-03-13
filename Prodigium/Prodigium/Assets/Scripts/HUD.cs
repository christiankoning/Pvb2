using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text Health;
    public Text Collectibles;
    public Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        Health.text = player.Health + "";
        //Collectibles.text = player.collected + "/3";
    }
}
