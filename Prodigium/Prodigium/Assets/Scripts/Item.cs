using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public Player player;
    public Inventory inventory;
    private string itemname;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        inventory = FindObjectOfType<Inventory>();
        itemname = gameObject.name;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Destroy(gameObject);
        }
    }
}
