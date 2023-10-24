using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "ScriptableObject/Equipment")]
public class Equipment : Item
{
    [SerializeField] EEquipmentType EquipmentType;
    [TextArea][SerializeField] string EquipmentDescription;

    public int MaxHealthMod, HealthMod, MaxManaMod, ManaMod, PowerMod, IntelligenceMod, SpeedMod, DefenseMod;

    public EEquipmentType GetEquipmentType() {  return EquipmentType; }

    public override void Use()
    {
        base.Use();

        GameManager.m_Instance.GetPlayer().GetComponent<UnitCharacter>().GetEquipment().Equip(this);

        RemoveItem();
    }

    public override void RemoveItem()
    {
        base.RemoveItem();

        Debug.Log("Removing Equipment...");
    }
}

public enum EEquipmentType {Head, MainHand_Weapon, OffHand_Weapon}
