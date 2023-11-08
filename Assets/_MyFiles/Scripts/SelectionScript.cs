using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    BattleManager BattleManager;

    private void Start()
    {
        BattleManager = GameManager.m_Instance.GetBattleManager();
        if (!BattleManager)
        {
            Debug.LogError("Battle Manager Not Recived!");
        }
    }

    private void OnMouseOver()
    {
        if (BattleManager)
        {
            BattleManager.SetCurrentSelection(this.gameObject);
        }
    }

    private void OnMouseExit()
    {
        if (BattleManager)
        {
            BattleManager.SetCurrentSelection(null);
        }
    }
}
