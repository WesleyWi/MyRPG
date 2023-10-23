using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]

public class Item : ScriptableObject
{
    [SerializeField]public string m_ItemName {  get; private set; }
    [SerializeField]public Sprite m_ItemIcon {  get; private set; }
    [TextArea][SerializeField] string ItemDescription;

    public virtual void Use()
    {
        Debug.Log(m_ItemName + "is Being Used!");
    }

    public void RemoveItem()
    {
        Debug.Log("Removing Item...");

        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetInventory().RemoveItem(this);
    }

}
