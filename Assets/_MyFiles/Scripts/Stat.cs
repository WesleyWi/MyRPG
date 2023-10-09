using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField] private string StatName;
    [SerializeField] private int BaseValue;
    private List<int> modifiers = new List<int>();

    public int GetBaseValue() 
    { return BaseValue; }

    public void SetBasedValue(int value) 
    { BaseValue = value; }

    public string GetSatName() 
    {  return StatName; }

    public void SetStatName(string nameToSet) 
    {  StatName = nameToSet; }

    public int GetValue()
    {
        int totalValue = BaseValue;
        modifiers.ForEach(x => totalValue += x);
        return totalValue;
    }

    public void AddModifier(int modifier) 
    { if (modifier != 0) modifiers.Add(modifier); }

    public void RemoveModifier(int modifier) 
    { if (modifier != 0) modifiers.Remove(modifier); }
}
