using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCharacter : MonoBehaviour
{
    private CharacterStats CharacterStatProfile;
    [SerializeField] private EUnitType _UnitType;
    [SerializeField] private int DiceNumber;
    [SerializeField] private Inventory CharacterInventory;
    private void Awake()
    {
        CharacterStatProfile = gameObject.AddComponent<CharacterStats>();
        CharacterInventory = gameObject.AddComponent<Inventory>();
        CharacterInventory.SetInentorySpace(15);
    }

    public CharacterStats GetCharacterStats() { return CharacterStatProfile; }
    public EUnitType GetUnitType() { return _UnitType; }
    public int GetDiceNumber() { return DiceNumber; }
    public void SetDiceNumber(int valueToSet) { DiceNumber = valueToSet;  }

    public Inventory GetInventory() { return CharacterInventory;}

    public void SetInventory(List<Item> itemToSet)
    {
        CharacterInventory.GetItemList().Clear();
        CharacterInventory.GetItemList().AddRange(itemToSet);
    }
}
public enum EUnitType { Player, Partner, Enemy, NPC}
