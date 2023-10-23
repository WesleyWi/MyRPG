using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementAI : MonoBehaviour
{
    private NavMeshAgent NavAgent;
    private Animation Anim;
    private Transform PlayerPos;
    private Vector3 PrevPos;

    private float CurrentSpeed = 0;

    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        Vector3 curMove = transform.position - PrevPos;
        CurrentSpeed = curMove.magnitude / Time.deltaTime;
        PrevPos = transform.position;

        if (PlayerPos)
        {
            NavAgent.destination = PlayerPos.position;
        }
        
    }

    private IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.25f);

        PlayerPos = GameManager.m_Instance.GetPlayer().transform;
        if (!PlayerPos)
        {
            Debug.Log("Player Pos Not Found!");
        }
    }
}
