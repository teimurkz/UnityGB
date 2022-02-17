using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] PatrolPoints;
    private int pointIndex;
    private NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
 
    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance <= 0.5f)
        {
            SetPatrolPoints();
        }  
    }
    void SetPatrolPoints()
    {
        var dest = PatrolPoints[pointIndex % PatrolPoints.Length].position;
        agent.destination = dest;
        pointIndex++;
    }
}
