using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> TurnOrder = new List<GameObject>();
    [SerializeField] private bool BattleStarted = false;
    [SerializeField] private EBattleState BattleState = EBattleState.Wait;
    [SerializeField] private float TransitionTime = 3f;
    private List<GameObject> EnemyList = new List<GameObject>();

    private BattleUIManager BattleUI;

    public EBattleState GetBattleState() { return BattleState; }

    public void SetBattleState(EBattleState stateToSet) { BattleState = stateToSet; }

    public void InitializeBattle(List<GameObject> enemyBattleList)
    {
        if (BattleStarted == false)
        {
            Debug.Log("Initislizing Battle...");

            GameObject BattleUIClone = Instantiate(GameManager.m_Instance.GetBattleUI(), this.gameObject.transform, false);
            BattleUI = BattleUIClone.GetComponent<BattleUIManager>();

            EnemyList.Clear();
            EnemyList.AddRange(enemyBattleList);

            GatherUnits();
            OrderByDiceRoll();
            //Start First State of Battle
            SetBattleState(EBattleState.StartBattle);
            StartCoroutine(BattleStart());
        }
    }

    public IEnumerator BattleStart()
    {
        //Battle Transition
        //Move camera or load Level

        yield return new WaitForSeconds(TransitionTime);

        SetBattleState(EBattleState.ChooseTurn);
    }

    public void ChooseTurn()
    {
        UnitCharacter currentTurn = TurnOrder[0].GetComponent<UnitCharacter>();
    }
    public void GatherUnits()
    {
        TurnOrder.Add(GameManager.m_Instance.GetPlayer());
        TurnOrder.AddRange(GameManager.m_Instance.GetPartyManager().GetPartyList());
        TurnOrder.AddRange(EnemyList);
    }

    public void OrderByDiceRoll()
    {
        foreach (GameObject unit in TurnOrder)
        {
            unit.GetComponent<UnitCharacter>().SetDiceNumber(GameManager.m_Instance.DiceRoll());
        }

        TurnOrder = TurnOrder.OrderBy(x => x.GetComponent<UnitCharacter>().GetDiceNumber()).ToList();
        TurnOrder.Reverse();
    }

    public void EndTurn()
    {
        GameObject turnHolder = TurnOrder[0];
        TurnOrder.RemoveAt(0);
        TurnOrder.Insert(TurnOrder.Count, turnHolder);
    }

}

public enum EBattleState { Wait, StartBattle, ChooseTurn, PlayerTurn, EnemyTurn, BattleWon, BattleLost}
