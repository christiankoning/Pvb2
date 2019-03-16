using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public Inventory inventory;

    void Start()
    {
        inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventorypanel = transform.Find("InventoryPanel");
        int index = -1;
        foreach (Transform slot in inventorypanel)
        {
            index++;
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            Text text = slot.GetChild(0).GetChild(1).GetComponent<Text>();

            if (index == e.Item.Slot.Id)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                int itemCount = e.Item.Slot.Count;
                if(itemCount > 1)
                {
                    text.text = itemCount.ToString();
                }
                else
                {
                    text.text = "";
                }

                break;
            }
        }
    }
}
