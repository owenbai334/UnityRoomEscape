using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostEnemy : MonoBehaviour
{
    //導航組件
    NavMeshAgent navMeshAgent;
    //導航陣列
    public Transform[] wayPoint;
    //目前巡邏目標點索引
    int wayIndex;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(wayPoint[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(navMeshAgent.remainingDistance<navMeshAgent.stoppingDistance)
        {
            wayIndex = (wayIndex+1)%wayPoint.Length;
            navMeshAgent.SetDestination(wayPoint[wayIndex].position);
        }
    }
}
