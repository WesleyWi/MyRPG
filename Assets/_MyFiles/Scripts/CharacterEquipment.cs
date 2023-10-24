using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    [SerializeField] Equipment[] CurrentEquipment = new Equipment[System.Enum.GetNames(typeof(EEquipmentType)).Length];

    public void Equip(Equipment gear)
    {
        int equipmentIndex = (int)gear.GetEquipmentType();

        if (CurrentEquipment[equipmentIndex] != null)
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
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Health).AddModifier(gear.HealthMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.MaxMana).AddModifier(gear.MaxManaMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Mana).AddModifier(gear.ManaMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Power).AddModifier(gear.PowerMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Intelligence).AddModifier(gear.IntelligenceMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Speed).AddModifier(gear.SpeedMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Defense).AddModifier(gear.DefenseMod);
        //

    }

    private void UnequipMods(Equipment gear)
    {
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.MaxHealth).AddModifier(gear.MaxHealthMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Health).AddModifier(gear.HealthMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.MaxMana).AddModifier(gear.MaxManaMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Mana).AddModifier(gear.ManaMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Power).AddModifier(gear.PowerMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Intelligence).AddModifier(gear.IntelligenceMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Speed).AddModifier(gear.SpeedMod);
        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetCharacterStats().Getstat(StatType.Defense).AddModifier(gear.DefenseMod);
    }


}
