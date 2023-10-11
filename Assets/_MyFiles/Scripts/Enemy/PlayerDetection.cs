using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(BringIntoBattle))]
public class PlayerDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BringIntoBattle bringIntoBattle = GetComponent<BringIntoBattle>();
        if (other.CompareTag(EUnitType.Player.ToString()) && bringIntoBattle)
        {
            Debug.Log("Player hit, Start Battle...");
            GameManager.m_Instance.CreateBattleManager(bringIntoBattle.GetEnemyPartnerList());
        }
        else
        {
            Debug.LogError("Missing Player with Tag or BringInToBattle Script on Enemy");
        }
    }
}
