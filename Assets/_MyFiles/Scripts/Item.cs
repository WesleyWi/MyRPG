using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]

public class Item : ScriptableObject
{
    public string m_ItemName;
    public Sprite m_ItemIcon;
    [TextArea][SerializeField] string ItemDescription;

    public virtual void Use()
    {
        Debug.Log(m_ItemName + "is Being Used!");
    }

    public virtual void RemoveItem()
    {

        Debug.Log("Removing Item...");

        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetInventory().RemoveItem(this);
    }

}
