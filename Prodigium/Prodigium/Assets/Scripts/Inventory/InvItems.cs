using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvItems : InventoryItemBase {

	public override string Name
    {
        get
        {
            return this.name;
        }
    }

    public override Sprite Image
    {
        get
        {
            return GetComponent<SpriteRenderer>().sprite;
        }
    }

    public override void OnPickUp()
    {
        gameObject.SetActive(false);
    }

    public GameObject player;
    public Inventory inventory;

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
        }
    }
}
