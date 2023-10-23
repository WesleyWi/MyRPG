using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    [SerializeField] Equipment[] CurrentEquipment = new Equipment[System.Enum.GetNames(typeof(EEquipmentType)).Length];

    public void Equip(Equipment gear)
    {
        int equipmentIndex = (int)gear.GetEquipmentType();

        if (CurrentEquipment[equipmentIndex] == null)
        {
            Equipment oldItem = null;

            oldItem = CurrentEquipment[equipmentIndex];
            UnequipMods(oldItem);
        }

        CurrentEquipment[equipmentIndex] = gear;
        EquipMods(gear);
    }

    public void Unequip(int EquipmentIndex)
    {
        if ()
        {

        }
    }

    private void EquipMods(Equipment gear)
    {
        //FIX THIS
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.MaxHealth).AddModifier(gear.MaxHealthMod);
        //

    }


}
