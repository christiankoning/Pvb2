using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour, IInventoryItem
{
    public virtual string Name
    {
        get
        {
            return "_base Item_";
        }
    }

    public InventorySlot Slot
    {
        get; set;
    }

    public Sprite _Image;

    public virtual Sprite Image
    {
        get { return _Image; }
    }


    public virtual void OnPickUp()
    {
        gameObject.SetActive(false);
    }
}
