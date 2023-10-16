using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCharacter : MonoBehaviour
{
    private CharacterStats CharacterStatProfile;
    [SerializeField] private EUnitType _UnitType;
    [SerializeField] private int DiceNumber;
    private void Awake()
    {
        CharacterStatProfile = gameObject.AddComponent<CharacterStats>();
    }

    public CharacterStats GetCharacterStats() { return CharacterStatProfile; }
    public EUnitType GetUnitType() { return _UnitType; }
    public int GetDiceNumber() { return DiceNumber; }
    public void SetDiceNumber(int valueToSet) { DiceNumber = valueToSet;  }
}
public enum EUnitType { Player, Partner, Enemy, NPC}
