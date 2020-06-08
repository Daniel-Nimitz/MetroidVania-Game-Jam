using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    private void Start()
    {
        target = GameObject.Find("Enemy Goes Here").transform;
        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(target.position);
    }

    private void Update()
    {
        
    }
}
