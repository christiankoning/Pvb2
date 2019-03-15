using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public GameObject player;
    public Inventory inventory;
    private string itemname;

    public SoundManager SManager;

    private void Start()
    {
        player = GameObject.Find("Player");
        inventory = FindObjectOfType<Inventory>();
        SManager = FindObjectOfType<SoundManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            SManager.AudioCollecting.Play();
            Destroy(gameObject);
        }
    }
}
