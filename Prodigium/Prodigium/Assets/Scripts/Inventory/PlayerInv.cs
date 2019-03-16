using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour {

    public Inventory inventory;

    private void OnTriggerEnter(Collider hit)
    {
        IInventoryItem item = hit.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }
}
