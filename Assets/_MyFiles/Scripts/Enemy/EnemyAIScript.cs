using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIScript : MonoBehaviour
{
    public GameObject[] waypoints;
    [SerializeField] Transform targetPos;

    NavMeshAgent enemy_NavMeshAgent;
    Animator enemy_Animator;
    int waypointIndex;
    Vector3 prevPosition;
    public float curSpeed;
    public float followRange = 10f;

    private void Start()
    {
        GameObject playerHolder = GameObject.FindGameObjectWithTag("Player");
        if (playerHolder != null)
        {
            targetPos = playerHolder.transform;
        }
        else
        {
            Debug.LogError("Player not found!");
        }
        if (waypoints.Length <= 0)
        {
            Debug.LogError("There are no Waypoints in Waypoints Array!");
        }
        prevPosition = transform.position;
        waypointIndex = 0;
        enemy_NavMeshAgent = GetComponent<NavMeshAgent>();
        enemy_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Setting current Speed
        Vector3 curMove = transform.position - prevPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        prevPosition = transform.position;
        enemy_Animator.SetFloat("Speed", curSpeed);

        //Player Detection
        float targetDistance = Vector3.Distance(transform.position, targetPos.position);
        if (targetDistance <= followRange)
        {
            enemy_NavMeshAgent.destination = targetPos.position;
        }
        else
        {
            //Waypoints
            if (waypoints.Length > 0)
            {
                float waypointDistance = Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position);
                enemy_NavMeshAgent.destination = waypoints[waypointIndex].transform.position;
                if (waypointDistance < 1f)
                {
                    waypointIndex++;
                    if (waypointIndex >= waypoints.Length)
                    {
                        waypointIndex = 0;
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }
}
