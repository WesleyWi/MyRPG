using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Attack(UnitCharacter targetToAttack)
    {
        Debug.Log(this.name + " Attacks " +  targetToAttack.name);
    }

    public void Heal(UnitCharacter targetToAttack)
    {
        Debug.Log(this.name + " Heals " + targetToAttack.name);
    }
}
