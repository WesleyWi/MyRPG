using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventroyUIManager : MonoBehaviour
{
    [SerializeField] private Transform InventoryGRP;
    private ItemSlot[] ItemSlots;


    private void Start()
    {
        InventoryGRP = GameObject.FindGameObjectWithTag("InventoryGRP").transform;
        ItemSlots = InventoryGRP.GetComponentsInChildren<ItemSlot>();
    }

    public void UpdateUI(List<Item> itemsToUpdate)
    {
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            if (i < itemsToUpdate.Count)
            {
                ItemSlots[i].AddItem(itemsToUpdate[i]);
            }
            else
            {
                ItemSlots[i].ClearItem();
            }
        }
    }
}
