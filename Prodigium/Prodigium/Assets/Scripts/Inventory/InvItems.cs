using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvItems : MonoBehaviour, IInventoryItem {

	public string Name
    {
        get
        {
            return this.name;
        }
    }


    public Sprite Image
    {
        get
        {
            return GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }
}
