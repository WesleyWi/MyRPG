using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCharacter : MonoBehaviour
{
    private CharacterStats CharacterStatProfile;
    private EUnitType _UnitType;
    private void Awake()
    {
        CharacterStatProfile = gameObject.AddComponent<CharacterStats>();
    }

    public CharacterStats GetCharacterStats() { return CharacterStatProfile; }
}
public enum EUnitType { Player, Partner, Enemy, NPC}
