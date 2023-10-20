using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Range(1,15)][SerializeField] private int InventorySpace;

    [SerializeField] private List<Item> Item = new List<Item>();

    public int GetInventorySpace() {  return InventorySpace; }
    public void SetInentorySpace(int spaceToSet) { InventorySpace = spaceToSet; }
    public List<Item> GetItemList() { return Item; }
    public bool AddItem(Item itemToAdd)
    {
        if (itemToAdd != null && Item.Count < InventorySpace)
        {
            Item.Add(itemToAdd);
            GameManager.m_Instance.GetInventroyUIManager().UpdateUI(Item);
            return true;
        }
        else 
        { 
            Debug.Log("Inventory Full");
            return false;
        }

    }

    public void RemoveItem(Item itemToRemove)
    {
        if (itemToRemove != null)
        {
            Item.Remove(itemToRemove);
            GameManager.m_Instance.GetInventroyUIManager().UpdateUI(Item);
        }
    }

}
