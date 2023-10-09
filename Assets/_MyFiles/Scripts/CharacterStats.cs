using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private string CharacterName;
    [SerializeField] private string CharacterDescription;

    [SerializeField] private List<Stat> characterStats = new List<Stat>();

    private void Awake()
    {
        for (int i = 0; i < (int)StatType.COUNT; i++)
        {
            StatType type = (StatType)i;
            Stat newStat = new Stat();
            if (type == StatType.Health || type == StatType.MaxHealth ||
                type == StatType.Mana || type == StatType.Mana)
            {
                newStat.SetBasedValue(100);
            }
            else
            {
                newStat.SetBasedValue(3);
            }
            newStat.SetStatName(type.ToString());
            characterStats.Add(newStat);
        }
    }

    public Stat Getstat(StatType statToGet)
    {
        string nameToGet = statToGet.ToString();
        foreach (Stat stat in characterStats)
        {
            if (stat.GetSatName() == nameToGet)
            {
                return stat;
            }
        }
        return null;

    }
}

public enum StatType { MaxHealth, Health, MaxMana, Mana, Power, Intelligence, Defense, COUNT}
