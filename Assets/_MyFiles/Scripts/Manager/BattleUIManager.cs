using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUIManager : MonoBehaviour
{
    private BattleManager CurrentBattle;
    [SerializeField] private GameObject PlayerUIPanel;
    [SerializeField] private Animator TransitionPanelANIM;
    [SerializeField] private GameObject BattleStartPostP;

    private void Start()
    {
        CurrentBattle = GameManager.m_Instance.GetBattleManager();
        if (CurrentBattle)
        {
            Debug.Log("BattleUIManager: Connected to CurrentBattle!");
        }
        else
        {
            Debug.LogError("BattleUIManager: CurrentBattle Not Found!");
        }
    }

    public GameObject GetPlayerUIPanel() { return PlayerUIPanel; }

    public void PlayTransition()
    {
        TransitionPanelANIM.SetTrigger("PlayTransition");
    }

    public void EndTransition()
    {
        TransitionPanelANIM.SetTrigger("EndTransition");
    }

    public void EndTurnBatton()
    {
        if (CurrentBattle) { CurrentBattle.EndTurn(); }
    }


}
