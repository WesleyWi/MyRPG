using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [SerializeField] private Item ItemProfile;

    public void OnTriggerEnter(Collider other)
    {
        UnitCharacter character = other.GetComponent<UnitCharacter>();

        if (character && character.GetUnitType() == EUnitType.Player)
        {
            //Add Item To Inventory
            Debug.Log("Item Get!");
            bool InventoryNotFull = other.GetComponent<UnitCharacter>().GetInventory().AddItem(ItemProfile);
            if(InventoryNotFull)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
