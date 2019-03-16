using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 49;

    private List<InventorySlot> mSlots = new List<InventorySlot>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public Inventory()
    {
        for(int i = 0; i < SLOTS; i++)
        {
            mSlots.Add(new InventorySlot(i));
            
        }
    }

    private InventorySlot FindStackableSlot(IInventoryItem item)
    {
        foreach(InventorySlot slot in mSlots)
        {
            if(slot.IsStackable(item))
            {
                return slot;
            }
        }
        return null;
    }

    private InventorySlot FindNextEmptySlot()
    {
        foreach(InventorySlot slot in mSlots)
        {
            if(slot.IsEmpty)
            {
                return slot;
            }
        }
        return null;
    }

    public void AddItem(IInventoryItem item)
    {
        InventorySlot freeslot = FindStackableSlot(item);
        if(freeslot == null)
        {
            freeslot = FindNextEmptySlot();
        }
        if(freeslot != null)
        {
            freeslot.AddItem(item);
            item.OnPickUp();

            if(ItemAdded != null)
            {
                ItemAdded(this, new InventoryEventArgs(item));
            }
        }
    }
}
