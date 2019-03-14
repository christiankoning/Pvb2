using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public GameObject player;
    public Inventory inventory;
    private string itemname;

    private void Start()
    {
        player = GameObject.Find("Player");
        inventory = FindObjectOfType<Inventory>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Destroy(gameObject);
        }
    }
}
