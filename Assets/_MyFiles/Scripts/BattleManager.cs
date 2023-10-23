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

    public EBattleState GetBattleState() { return BattleState; }

    public void SetBattleState() {  BattleState = EBattleState.Wait;}

    public void InitializeBattle(List<GameObject> enemyBattleList)
    {
        if (BattleStarted == false)
        {
            Debug.Log("Initislizing Battle...");
            BattleStarted = true;

            EnemyList.Clear();
            EnemyList.AddRange(enemyBattleList);

            GatherUnits();
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
        if ()
        {

        }
    }
    public void GatherUnits()
    {
        TurnOrder.Clear(); // Clear the TurnOrder list before adding units.

        var gameManager = GameManager.m_Instance; // Get a reference to the GameManager instance.

        if (gameManager != null)
        {
            var player = gameManager.GetPlayer(); // Attempt to get the player object from GameManager.
            if (player != null)
            {
                TurnOrder.Add(player); // If the player is not null, add it to the TurnOrder list.
            }

            var partyManager = gameManager.GetPartyManager(); // Attempt to get the PartyManager object from GameManager.
            var partyList = partyManager?.GetPartyList(); // Use the null-conditional operator to get the party list safely.

            if (partyList != null)
            {
                TurnOrder.AddRange(partyList); // If the party list is not null, add its members to the TurnOrder list.
            }
        }

        TurnOrder.AddRange(EnemyList); // Add enemy units from the EnemyList.
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

public enum EBattleState { Wait, StartBattle,}
