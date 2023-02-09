using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (NavMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            //Action
        }
    }
    public void Move(Vector3 position)
    {
        NavMeshAgent.destination = position;
    }
}
