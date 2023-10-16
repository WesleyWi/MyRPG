using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Item m_ItemProfile;

    public void OnTriggerEnter(Collider other)
    {
        UnitCharacter character = other.GetComponent<UnitCharacter>();

        if (character && character.GetUnitType() == EUnitType.Player)
        {
            //Add Item To Inventory
            Debug.Log("Item Get!");

            Destroy(this.gameObject);
        }
    }
}
